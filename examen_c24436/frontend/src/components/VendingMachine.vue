<template>
  <div class="container-xxl border border-black border-5 my-5">
    <h1 class="display-1 text-center mb-5">Braunny's Vending Machine</h1>

    <DrinksList 
      :drinks="totalDrinks" 
      :cashSymbol="cashSymbol"
    />

    <DrinksAdder
      :totalDrinks="totalDrinks"
      :currentDrinks="currentDrinks"
      :errorMessages="errorMessages"
      @outputMessage="outputMessage"
      @addDrinks="addDrinks"
    />

    <MoneyAdder
      :cashSymbol="cashSymbol"
      :errorMessages="errorMessages"
      @outputMessage="outputMessage"
      @addMoney="addMoney"
    />

    <SelfCheckout
      :currentDrinks="currentDrinks"
      :currentMoney="currentMoney"
      :errorMessages="errorMessages"
      :cashSymbol="cashSymbol"
      :successMessages="successMessages"
      @outputMessage="outputMessage"
      @resetPurchase="resetPurchase"
      @handleSuccessfulPayment="handleSuccessfulPayment"
    />

    <OutputPanel
      :informationMessage="informationMessage"
      :cashSymbol="cashSymbol"
      :showChange="showChange"
      :successMessages="successMessages"
    />
  </div>
</template>

<script>
  import DrinksList from './DrinksList.vue';
  import DrinksAdder from './DrinksAdder.vue';
  import MoneyAdder from './MoneyAdder.vue';
  import SelfCheckout from './SelfCheckout.vue';
  import OutputPanel from './OutputPanel.vue';

  export default {
    components: {
      DrinksList,
      DrinksAdder,
      MoneyAdder,
      SelfCheckout,
      OutputPanel,
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
            message: "Error: The quantity of drinks must not exceed the available quantity.",
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
          this.outputMessage(this.errorMessages.unknown.message);
        }
      },

      outputMessage(message) {
        this.showChange = false;
        this.informationMessage = message;
      },

      outputChange(change) {
        this.showChange = true;
        this.informationMessage = change;
      },

      addDrinks(selectedDrink) {
        try {
          let drink = this.totalDrinks.find((drink) => drink.name === selectedDrink.name);
          let repeatedDrink = this.currentDrinks.find((drink) => drink.name === selectedDrink.name);
          if (repeatedDrink === undefined) {
            this.currentDrinks.push(
              {
                name: drink.name, 
                price: drink.price, 
                quantity: selectedDrink.quantity,
              }
            );
          } else {
            repeatedDrink.quantity += selectedDrink.quantity;
          }
          this.outputMessage(this.successMessages.addingDrinks);
        } catch {
          this.outputMessage(this.errorMessages.unknown.message);
        }
      },

      addMoney(selectedMoney) {
        try {
          let repeatedMoney = this.currentMoney.find((money) => money.type === selectedMoney.type);
          if (repeatedMoney === undefined) {
            this.currentMoney.push(
              {
                type: selectedMoney.type,
                quantity: selectedMoney.quantity,
              }
            );
          } else {
            repeatedMoney.quantity += selectedMoney.quantity;
          }
          this.outputMessage(this.successMessages.addingMoney);
        } catch {
          this.outputMessage(this.errorMessages.unknown.message);
        }
      },

      resetPurchase() {
        this.currentDrinks = [];
        this.currentMoney = [];
      },

      handleSuccessfulPayment(change) {
        this.resetPurchase();
        this.getDrinks();
        this.outputChange(change);
      },
    },

    mounted() {
      this.getDrinks();
    },
  };
</script>

<style>
</style>