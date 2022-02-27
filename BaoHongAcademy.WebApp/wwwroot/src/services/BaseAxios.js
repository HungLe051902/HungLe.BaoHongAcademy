import axios from "axios";
import { getToken, logout } from "@/helpers/authenticationHelper.js";
import { notify } from "@kyvg/vue3-notification";
import router from "../router";

export const HTTP = axios.create({
  baseURL: `https://localhost:44303/api`,
  timeout: 50000,
  headers: {
    "Access-Control-Allow-Origin": "*",
  },
});

HTTP.interceptors.request.use((request) => {
  var token = getToken();
  if (token) {
    request.headers.common.Authorization = `Bearer ${getToken()}`;
  }
  return request;
});

HTTP.interceptors.response.use(
  // Any status code that lie within the range of 2xx cause this function to trigger
  // Do something with response data
  function(response) {
    return response;
  },
  // Any status codes that falls outside the range of 2xx cause this function to trigger
  // Do something with response error
  function(error) {
    if (error?.response?.status === 401) {
      logout();
      router.push("/not-authorize");
    } else {
      notify({
        type: "error", // warn, error, success
        title: "Thất bại",
        text: "Có lỗi xảy ra. Vui lòng thử lại!",
      });
    }

    return Promise.reject(error);
  }
);
