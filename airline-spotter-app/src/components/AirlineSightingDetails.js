import React from 'react';

const AirlineSightingDetails = ({ sighting }) => {
    return (
        <div>
            <h2>Airline Sighting Details</h2>
            {sighting && (
                <div>
                    <p>Name: {sighting.name}</p>
                    <p>Short Name: {sighting.shortName}</p>
                    <p>Airline Code: {sighting.airlineCode}</p>
                    <p>Location: {sighting.location}</p>
                    <p>Created Date: {sighting.createdDate}</p>
                </div>
            )}
        </div>
    );
};

export default AirlineSightingDetails;