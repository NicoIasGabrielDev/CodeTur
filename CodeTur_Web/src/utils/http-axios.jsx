import axios from "axios";

export default axios.create({
  baseURL: "http://192.168.1.2:5000/v1/",
  headers: {
    "Content-type": "application/json"
  }
});
