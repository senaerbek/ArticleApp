export const API_BASE = "http://localhost:5000/api";
export const headers = {
    'Content-Type': 'multipart/form-data',
    'Authorization':"Bearer "+ localStorage.getItem("token")
}