import * as React from "react";
import { transform } from "ol/proj";
import Map from "ol/Map";
import View from "ol/View";
import Feature from "ol/Feature";
import SourceVector from "ol/source/Vector";
import LayerVector from "ol/layer/Vector";
import Tile from "ol/layer/Tile";
import Point from "ol/geom/Point";
import OSM from "ol/source/OSM";
import Polyline from "ol/format/Polyline";
import Grid from "@material-ui/core/Grid"

import { centerMap } from "./../../utils/mapUtils";
import { routeStyles, selectedRouteStyle } from "./../../utils/mapStyles";
import { DriverRoutesSugestions } from "./Route/DriverRoutesSugestions";
import { PassengerRouteSelection } from "./Route/PassengerRouteSelection";
import { PassengerNavigationButton } from "./PassengerNavigationButton";
import { OfficeAddresses } from "../../utils/AddressData";
import api from "./../../helpers/axiosHelper";
import { fromLonLatToMapCoords, fromMapCoordsToLonLat, 
  getNearest, coordinatesToLocation, createPointFeature } from "../../utils/mapUtils";
import { fromLocationIqResponse, addressToString } from "../../utils/addressUtils";

import "./../../styles/genericStyles.css";
import "../../styles/testmap.css";

export class PassengerMap extends React.Component {
  state = {
    passengerAddress: null,
    direction: "from",
    officeAddress: null
  }

  componentDidMount() {
    const {map, vectorSource} = this.initializeMap();
    this.map = map;
    this.vectorSource = vectorSource;
    this.updateMap();
  }

  initializeMap() {
    const vectorSource = new SourceVector();
    const vectorLayer = new LayerVector({source: vectorSource});
    const map = new Map({
      target: "map",
      controls: [],
      layers: [
        new Tile({
          source: new OSM()
        }),
        vectorLayer
      ],
      view: new View({
        center: fromLonLatToMapCoords(25.279652, 54.687157),
        zoom: 13
      })
    });
    map.on("click", e => {
      const [longitude, latitude] = fromMapCoordsToLonLat(e.coordinate);
      this.handleMapClick(longitude, latitude);
    });
    return {map, vectorSource};
  }

  updateMap() {
    this.vectorSource.clear();
    const {passengerAddress} = this.state;
    if (passengerAddress) {
      const {longitude, latitude} = passengerAddress;
      this.vectorSource.addFeature(createPointFeature(longitude, latitude));
    }
  }

  handleMapClick(longitude, latitude) {
    getNearest(longitude, latitude)
      .then(([long, lat]) => coordinatesToLocation(lat, long))
      .then(response => {
        const address = fromLocationIqResponse(response);
        this.autocompleteInput.value = response.display_name;
        this.setState({passengerAddress: address}, this.updateMap);
      });
  }

  onMeetupAddressChange(newAddress) {
    if (!OfficeAddresses.some(a => a == newAddress)) {
      this.autocompleteInput.value = addressToString(newAddress);
    }
    this.setState({passengerAddress: newAddress}, this.updateMap);
    if(newAddress) centerMap(newAddress.longitude, newAddress.latitude, this.map);
  }

  render() {
    return (
      <div>
        <div className="passengerForm">
          <PassengerRouteSelection 
              direction={this.state.direction}
              handleOfficeSelection={indexas => this.setState({officeAddress: OfficeAddresses[indexas]})}
              onDirectionChanged={(direction) => this.setState({direction: direction})}
              onMeetupAddressChange={address => this.onMeetupAddressChange(address)}
              ref={e => {
                if (e) {
                  this.autocompleteInput = e.autocompleteElem;
                }
              }}
          />
        </div>
        <div id="map"></div>
      </div>
    );
  }
}
export default PassengerMap;