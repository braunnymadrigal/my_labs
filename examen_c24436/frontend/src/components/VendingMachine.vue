<template>
  <div class="container-xxl border border-black border-5 my-5">
    <h1 class="display-1 text-center mb-5">Braunny's Vending Machine</h1>

    <DrinksList 
      :drinks="totalDrinks" 
      :cashSymbol="cashSymbol"
    />

  </div>
</template>

<script>
  import DrinksList from './DrinksList.vue';

  export default {
    components: {
      DrinksList,
    },

    data() {
      return {
        totalDrinks: [],

        cashSymbol:"₡",

        currentDrinks: [],

        currentMoney: [],
      
        informationMessage: "",

        showChange: false,

        errorMessages: {
          unknown: {
            message: "Error: Something unexpected happened. Please contact support.",
            expected: false,
          },
          aboveDrinkQuantity: {
            message: "Error: The quantity of drinks must not exceed the available stock.",
            expected: true,
          },
          belowDrinkQuantity: {
            message: "Error: The quantity of drinks must be greater than zero.",
            expected: true,
          },
          drinkName: {
            message: "Error: The selected drink does not exist.",
            expected: true,
          },
          moneyType: {
            message: "Error: The selected type of money is not supported.",
            expected: true,
          },
          belowMoneyQuantity: {
            message: "Error: The amount of money must be greater than zero.",
            expected: true,
          },
          moneyBelowCost: {
            message: "Error: Please insert enough money to cover the total cost.",
            expected: true,
          },
          failedPurchase: {
            message: "Error: Purchase failed. The system is currently out of service.",
            expected: true,
          },
        },

        successMessages: {
          addingDrinks: "Drinks have been successfully added!",
          addingMoney: "Money has been successfully added!",
          finalizingPurchase: "The purchase has been successfully finalized!",
          resettingPurchase: "The purchase has been successfully reset!",
        },
      };
    },

    methods: {
      async getDrinks() {
        try {
          const response = await this.$api.getDrinks();
          this.totalDrinks = response.data;
        } catch {
          console.log("error");
        }
      },
    },

    mounted() {
      this.getDrinks();
    },
  };
</script>

<style>
</style>