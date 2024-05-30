import React from 'react';
import AirlineSightingService from '../services/AirlineSightingService';

class AddAirlineSightingForm extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            name: '',
            shortName: '',
            airlineCode: '',
            location: '',
            createdDate: '',
            errorMessage: ''
        };
    }

    handleChange = event => {
        const { name, value } = event.target;
        this.setState({ [name]: value });
    };

    handleSubmit = async event => {
        event.preventDefault();
        const { name, shortName, airlineCode, location, createdDate } = this.state;
        try {
            await AirlineSightingService.addAirlineSighting({ name, shortName, airlineCode, location, createdDate });
            this.setState({
                name: '',
                shortName: '',
                airlineCode: '',
                location: '',
                createdDate: '',
                errorMessage: ''
            });
            
        } catch (error) {
            this.setState({ errorMessage: 'Error adding airline sighting. Please try again.' });
            console.error('Error adding airline sighting:', error);
        }
    };

    render() {
        const { name, shortName, airlineCode, location, createdDate, errorMessage } = this.state;
        return (
            <div>
                <h2>Add Airline Sighting</h2>
                {errorMessage && <p style={{ color: 'red' }}>{errorMessage}</p>}
                <form onSubmit={this.handleSubmit}>
                    <div>
                        <label>Name:</label>
                        <input type="text" name="name" value={name} onChange={this.handleChange} required />
                    </div>
                    <div>
                        <label>Short Name:</label>
                        <input type="text" name="shortName" value={shortName} onChange={this.handleChange} required />
                    </div>
                    <div>
                        <label>Airline Code:</label>
                        <input type="text" name="airlineCode" value={airlineCode} onChange={this.handleChange} required />
                    </div>
                    <div>
                        <label>Location:</label>
                        <input type="text" name="location" value={location} onChange={this.handleChange} required />
                    </div>
                    <div>
                        <label>Created Date:</label>
                        <input type="datetime-local" name="createdDate" value={createdDate} onChange={this.handleChange} required />
                    </div>
                    <button type="submit">Add Sighting</button>
                </form>
            </div>
        );
    }
}

export default AddAirlineSightingForm;