import * as React from "react";

export class RideRequestsList extends React.Component {
    render(){
        return(
            <div>
<tbody>
{
this.props.requests.map(req =>
<tr key={req.id}>
<td>{req.driverEmail}</td>
</tr>

)
}
</tbody>
</div>
        );
    }
}