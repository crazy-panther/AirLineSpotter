import React from 'react';
import AirlineSightingService from '../services/AirlineSightingService';

class AirlineSightingsList extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            sightings: []
        };
    }

    componentDidMount() {
        this.fetchAirlineSightings();
    }

    async fetchAirlineSightings() {
        try {
            const response = await AirlineSightingService.getAirlineSightings();
            this.setState({ sightings: response.data });
        } catch (error) {
            console.error('Error fetching airline sightings:', error);
        }
    }

    render() {
        return (
            <div>
                <h2>Airline Sightings</h2>
                <ul>
                    {this.state.sightings.map(sighting => (
                        <li key={sighting.id}>
                            <p>Name: {sighting.name}</p>
                            <p>Short Name: {sighting.shortName}</p>
                            <p>Airline Code: {sighting.airlineCode}</p>
                            <p>Location: {sighting.location}</p>
                            <p>Created Date: {sighting.createdDate}</p>
                        </li>
                    ))}
                </ul>
            </div>
        );
    }
}

export default AirlineSightingsList;