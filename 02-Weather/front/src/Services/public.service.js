import { loadAbort } from '../utilities/load-abort-axios.utility.js';
import axios from 'axios';

const API_URL = "https://localhost:7294/api/weather";

export const getLocations = async () => {
    const controller = loadAbort();
    return {
        call: axios.get(`${API_URL}/locations`, {signal : controller.signal}), controller
    }
}