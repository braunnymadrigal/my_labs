import axios from "axios";

export default {
  install(app) {
    const apiBaseURL = "https://localhost:7159/api";

    app.config.globalProperties.$apiBaseURL = apiBaseURL;

    app.config.globalProperties.$api = {
      buyDrinks(requestPurchase) {
        return axios.post(`${apiBaseURL}/VendingMachine`, requestPurchase);
      },

      getSupportedMoney() {
        return axios.get(`${apiBaseURL}/MoneyEngine`);
      },

      getDrinks() {
        return axios.get(`${apiBaseURL}/DrinkEngine`);
      },
    };
  },
};
