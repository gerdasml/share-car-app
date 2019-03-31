import * as React from "react";
import Grid from "@material-ui/core/Grid";
import Typography from "@material-ui/core/Typography";
import Card from "@material-ui/core/Card";
import Button from "@material-ui/core/Button";
import CardActions from "@material-ui/core/CardActions";
import CardContent from "@material-ui/core/CardContent";
import "../../../styles/genericStyles.css";
import MapComponent from "../../Maps/MapComponent";
import ListItemText from "@material-ui/core/ListItemText";
import { ListItem } from "@material-ui/core";

export default class RidePassengerCard extends React.Component {
    state = {
        show: false
    }
    render() {
        return (
            <Grid item xs={12}>
                <Card className="passengers-card generic-card">
                    <Grid container justify="center" className="passengers-list">
                        <Grid item md={8}>
                            <ListItemText
                                primary={<span>{this.props.passenger.firstName} {this.props.passenger.lastName}</span>}
                                secondary={
                                    <React.Fragment>
                                        {this.props.passenger.phone !== null ? 
                                            <div>
                                                <Typography component="span" style={{display: 'inline'}} color="textPrimary">
                                                    Phone: &nbsp;
                                                </Typography>
                                                {this.props.passenger.phone}
                                            </div>
                                        : ""}
                                    </React.Fragment>
                                }
                            />
                        </Grid>
                        <Grid item md={4}>
                            <Button
                                variant="outlined"
                                onClick={() => { this.setState({ show: !this.state.show }) }}
                            >
                                Show on map
                            </Button>
                        </Grid>
                    </Grid>
                </Card>
                    {this.state.show ?
                        <Card className="requestMap rides-card generic-card">
                            <Grid container justify="center">
                                <Grid item xs={12} zeroMinWidth>
                                    <MapComponent
                                        pickUpPoint={{ longitude: this.props.passenger.longitude, latitude: this.props.passenger.latitude }}
                                        route={this.props.passenger.route}
                                        index={this.props.index}
                                    />
                                </Grid>
                            </Grid>
                        </Card>
                        : <div></div>}
            </Grid>
        );
    }
}