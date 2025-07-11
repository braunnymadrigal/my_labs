import axios from "axios";

export default {
  install(app) {
    const apiBaseURL = "https://localhost:7159/api";

    app.config.globalProperties.$apiBaseURL = apiBaseURL;

    app.config.globalProperties.$api = {
      registerCompany(companyData) {
        return axios.post(`${apiBaseURL}/Company`, companyData);
      },

      getProfile() {
        return axios.get(`${apiBaseURL}/Profile`);
      },
    };
  },
};
