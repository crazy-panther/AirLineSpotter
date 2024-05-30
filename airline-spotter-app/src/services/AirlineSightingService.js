// src/services/AirlineSightingService.js
import axios from 'axios';

const API_URL = 'http://localhost:5161/api/AirlineSightings';

class AirlineSightingService {
    async getAirlineSightings() {
        const response = await axios.get(API_URL);
        return response.data;
    }

    async getAirlineSighting(id) {
        const response = await axios.get(`${API_URL}/${id}`);
        return response.data;
    }

    async addAirlineSighting(sightingData) {
        const response = await axios.post(API_URL, sightingData);
        return response.data;
    }

    async updateAirlineSighting(id, sightingData) {
        const response = await axios.put(`${API_URL}/${id}`, sightingData);
        return response.data;
    }

    async deleteAirlineSighting(id) {
        const response = await axios.delete(`${API_URL}/${id}`);
        return response.data;
    }
}

export default new AirlineSightingService();
