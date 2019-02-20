import * as React from "react";
import axios from "axios";
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

import { centerMap } from "./../utils/mapUtils";
import { routeStyles, selectedRouteStyle } from "./../utils/mapStyles";
import { DriverRoutesSugestions } from "./DriverRoutesSugestions";
import { PassengerRouteSelection } from "./PassengerRouteSelection";
import { PassengerNavigationButton } from "./PassengerNavigationButton";
import { OfficeAddresses } from "./AddressData";
import api from "../helpers/axiosHelper";

import "../styles/genericStyles.css";

export class PassengerMap extends React.Component {
  state = {
    passengerPickUpPointFeature: null,
    selectedRoute: "",
    filteredRoute: {
      toOffice: false,
      office: OfficeAddresses[0],
      dateTimeFrom: "",
      dateTimeTo: ""
    }, // route object containing filttering information acocrding to which passenger will get route suggestions
    driversOfRoute: [],
    map: "",
    accessToken: "ad45b0b60450a4", // required for reverse geocoding api
    vectorSource: "",
    features: {
      startPointFeature: "",
      destinationFeature: ""
    },
    route: {
      fromAddress: "",
      toAddress: "",
      routeGeometry: ""
    },
    showDriver: false,
    showRides: false,
    ridesOfRoute: [],
    viewNext: false,
    passengerRoutes: [],
    passengerRouteFeatures: [],
    passengerRouteFeaturesCounter: 0,
    driverEmail: "",
    pickUpPoints: []
  };

  selectRoute(value) {
    let counter = this.state.passengerRouteFeaturesCounter;
    const features = this.state.passengerRouteFeatures;
    const featuresLength = features.length;
    
    if (featuresLength != 0) {
      this.state.showDriver = true;
      this.state.showRoutes = false;
      this.state.showRides = false;

      if (counter == 0) {
        this.state.passengerRouteFeatures[featuresLength - 1]
          .feature.setStyle(routeStyles.route);

        if (featuresLength != 1) {
          features[1].feature.setStyle(routeStyles.route);
        }
      } 
      else {
          features[counter - 1].feature.setStyle(routeStyles.route);
      
          if (value == -1) {
            if (counter != featuresLength - 1) {
              features[counter + 1].feature.setStyle(routeStyles.route);
            } 
            else {
                  features[0].feature.setStyle(routeStyles.route);
            }
          }
      }

      features[counter].feature.setStyle(selectedRouteStyle.route);
      this.setState(
        {
          selectedRoute: features[counter]
        },
        () => {
          counter += value;

          if (counter >= featuresLength) {
            counter = 0;
          }
          if (counter < 0) {
            counter = featuresLength - 1;
          }
          this.setState({ passengerRouteFeaturesCounter: counter });
          this.getRidesByRoute(this.state.selectedRoute.route);
        }
      );
    }
  }

  handleCloseDriver() {
    this.setState({ showDriver: false });
  }

  getRidesByRoute(route) {
    this.setState({ ridesOfRoute: route.rides, driversOfRoute: [] }, () => {
      var drivers = [];

      this.state.ridesOfRoute.forEach(ride => {
        if (!drivers.includes(ride.driverFirstName + ride.driverLastName)) {
          drivers.push(ride.driverFirstName + ride.driverLastName);

          var driversArray = this.state.driversOfRoute;
          driversArray.push({
            firstName: ride.driverFirstName,
            lastName: ride.driverLastName,
            email: ride.driverEmail,
            driverPhone: ride.driverPhone
          });

          this.setState({ driversOfRoute: driversArray });
        }
      });

      if (drivers.length != 0) {
        this.setState({ showDriver: true });
      } else {
        this.setState({ showDriver: false });
      }
    });
}

  handleOfficeSelection(e, indexas, button) {
    var index = e.target.value;   //why use it here?
    if (indexas) {
      var getState = this.state.filteredRoute;

      getState.office = OfficeAddresses[indexas];

      this.setState({ filteredRoute: getState });

      this.showRoutes();
    }
  }
  //removes passenger pick up point marker from map and clears states related with it
  handleFromOfficeSelection() {
    if (!this.state.filteredRoute.toOffice) {
      let pickupFeature = this.state.passengerPickUpPointFeature;
      if (pickupFeature) {
        this.state.vectorSource.removeFeature(
          pickupFeature
        );
        pickupFeature = null;
      }
      this.setState(
        {
          pickUpPoints: [
            this.state.filteredRoute.office.longtitude,
            this.state.filteredRoute.office.latitude
          ]
        }
      );
    }
  }

  showRoutes() {
    this.state.vectorSource.clear();
    centerMap(
      this.state.filteredRoute.office.longtitude,
      this.state.filteredRoute.office.latitude,
      this.state.map
    );
    this.setState({
      showDriver: true,
      showRoutes: false,
      driversOfRoute: [],
      driverEmail: "",
      showRides: false,
      passengerRouteFeaturesCounter: 0
    });
    let routeDto;
    this.state.filteredRoute.toOffice
      ? (routeDto = {
          AddressTo: this.buildAddress(this.state.filteredRoute)
        })
      : (routeDto = {
          AddressFrom: this.buildAddress(this.state.filteredRoute)
        });
    
    this.fetchRoutes(routeDto);
  }

  buildAddress(route) {
    return {
      City: route.office.city,
      Street: route.office.street,
      Number: route.office.number
    }
  }

  fetchRoutes(routeDto) {
    api.post("https://localhost:44360/api/Ride/routes", routeDto).then(res => {
      if (res.status == 200 && res.data != "") {
        this.setState({ passengerRoutes: res.data });
        this.state.passengerRouteFeatures = []; // deletes old routes

        this.state.passengerRoutes.forEach(element => {
          this.createPassengerRoute(element);
        });
      }
    });
  }

  createPassengerRoute(polyline) {
    this.state.route.routeGeometry = polyline.geometry;
    var route = new Polyline({
      factor: 1e5
    }).readGeometry(polyline.geometry, {
      dataProjection: "EPSG:4326",
      featureProjection: "EPSG:3857"
    });
    var feature = new Feature({
      type: "route",
      geometry: route
    });

    feature.setStyle(routeStyles.route);

    this.state.passengerRouteFeatures.push({
      feature: feature,
      geometry: polyline.geometry,
      route: polyline
    });

    this.state.vectorSource.addFeature(feature);
  }

  passengerAddressInputSuggestion() {
    var places = require("places.js");

    var placesAutocompletePassenger = places({
      container: document.querySelector("#passenger-address")
    });
    placesAutocompletePassenger.on("change", e => {
      centerMap(
        e.suggestion.latlng.lng,
        e.suggestion.latlng.lat,
        this.state.map
      );
    });
  }

  showRidesOfDriver(driver) {
    if (this.state.showRides) {
      if (driver.email == this.state.driverEmail) {
        this.setState({ showRides: false, driverEmail: "" });
      } else {
        this.setState({ driverEmail: driver });
      }
    } else {
      this.setState({ showRides: true, driverEmail: driver });
    }
  }

  handlePassengerMapClick(evt) {
    var feature = new Feature(new Point(evt.coordinate));
    var lonlat = [];
    lonlat = transform(evt.coordinate, "EPSG:3857", "EPSG:4326");
    this.setState({ pickUpPoints: lonlat });

    if (this.state.passengerPickUpPointFeature) {
      this.state.vectorSource.removeFeature(
        this.state.passengerPickUpPointFeature
      );
    }
    this.setState({ passengerPickUpPointFeature: feature });
    this.state.vectorSource.addFeature(feature);
  }

  componentDidMount() {
    var vectorSource = new SourceVector(),
      vectorLayer = new LayerVector({
        source: vectorSource
      });

    var map = new Map({
      target: "map",
      controls: [],
      layers: [
        new Tile({
          source: new OSM()
        }),
        vectorLayer
      ],
      view: new View({
        center: [-5685003, -3504484],
        zoom: 11,
        minZoom: 9
      })
    });

    this.setState({ map, vectorSource }, function() {
      centerMap(25.279652, 54.687157, this.state.map);

      this.showRoutes();
      this.passengerAddressInputSuggestion();

      if (this.state.filteredRoute.toOffice) {
      } else {
        this.handleFromOfficeSelection();
      }
    });

    map.on("click", evt => {
      if (this.state.filteredRoute.toOffice) {
        this.handlePassengerMapClick(evt);
      }
    });
  }

  render() {
    return (
      <div>
        <div className="passengerForm">
          <PassengerRouteSelection 
            filteredRouteToOffice={this.state.filteredRoute.toOffice}
            showRoutes={() => this.showRoutes()}
            directionToOffice={() => {
              this.state.filteredRoute.toOffice = true;
            }}
            handleFromOfficeSelection={() => this.handleFromOfficeSelection()}
            handleOfficeSelection={(e, indexas, button) =>
              this.handleOfficeSelection(e, indexas, button)
            }
          />
          <Grid container justify="center" className="algolia-input" item xs={10}>
            <input
              type="search"
              className="form-group"
              id="passenger-address"
              placeholder="Center map by location..."
            />
          </Grid>
          {this.state.showDriver ? (
            <DriverRoutesSugestions 
              driversOfRoute={this.state.driversOfRoute}
              showRides={this.state.showRides}
              ridesOfRoute={this.state.ridesOfRoute}
              driverEmail={this.state.driverEmail}
              pickUpPoints={this.state.pickUpPoints}
              handleCloseDriver={() => this.handleCloseDriver()}
              showRidesOfDriver={driver => this.showRidesOfDriver(driver)}
            />
          ) : (
            <div />
          )}
          <div />
        </div>
        <div id="map" />
        <PassengerNavigationButton 
          onClick={() => this.selectRoute(-1)}
          text="View Previous Route"
        />
        <PassengerNavigationButton 
          onClick={() => {
            this.setState({ viewNext: !this.state.viewNext });
            this.selectRoute(1);
          }}
          text="View Next Route"
        />
      </div>
    );
  }
}
export default PassengerMap;