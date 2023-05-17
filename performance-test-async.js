import http from "k6/http"
import { sleet } from "k6";

export const options = {
    vus: 100,
    duration: "30s"
}

export default function() {
    http.get("http://localhost:5031/WeatherForecast/GetAsync")
}