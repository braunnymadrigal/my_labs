<template>
  <div>
    <h2 class="display-5 text-center mt-5">Buy Drinks</h2>

    <div class="table-responsive">
      <table class="table table-bordered text-center">
        <thead class="table-dark">
          <tr class="h4">
            <th class="col-1">Cart</th>
            <th class="col-1">Inserted Amount</th>
            <th class="col-1">Action</th>
          </tr>
        </thead>
        <tbody class="table-secondary">
          <tr>
            <td class="align-top text-center">
              <h5 class="text-center text-capitalize">
                Total Cost: {{ cashSymbol }}{{ getDrinksCost() }}
              </h5>
              <div class="d-flex flex-wrap bg-dark text-white text-center py-2">
                <div class="flex-fill">Name</div>
                <div class="flex-fill">Price</div>
                <div class="flex-fill">Quantity</div>
                <div class="flex-fill">Total</div>
              </div>
              <div class="d-flex flex-wrap text-capitalize text-center py-4" v-for="(drink, index) in currentDrinks" :key="index">
                <div class="flex-fill">{{ drink.name }}</div>
                <div class="flex-fill">{{ cashSymbol }}{{ drink.price }}</div>
                <div class="flex-fill">{{ drink.quantity }}</div>
                <div class="flex-fill">{{ cashSymbol }}{{ drink.quantity * drink.price }}</div>
              </div>
            </td>

            <td class="align-top text-center">
              <h5 class="text-center text-capitalize">
                Total Inserted Money: {{ cashSymbol }}{{ getMoneyAmount() }}
              </h5>
              <div class="d-flex flex-wrap bg-dark text-white text-center py-2">
                <div class="flex-fill">Type</div>
                <div class="flex-fill">Quantity</div>
                <div class="flex-fill">Total</div>
              </div>
              <div class="d-flex flex-wrap text-capitalize text-center py-4" v-for="(money, index) in currentMoney" :key="index">
                <div class="flex-fill">{{ cashSymbol }}{{ money.type }}</div>
                <div class="flex-fill">{{ money.quantity }}</div>
                <div class="flex-fill">{{ cashSymbol }}{{ money.quantity * money.type }}</div>
              </div>
            </td>

            <td class="align-middle">
              <button class="btn btn-light btn-outline-dark btn-lg px-5 mx-2" @click="pay()">
                Pay
              </button>
              <button class="btn btn-light btn-outline-dark btn-lg px-5 mx-2" @click="reset()">
                Reset
              </button>
            </td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>

<script>
  export default {
    props: ['currentDrinks', 'currentMoney', 'errorMessages', 'cashSymbol', 'successMessages'],

    data() {
      return {
        drinksCost: 0,
        moneyAmount: 0,
      };
    },

    methods: {
      pay() {
        //
      },

      reset() {
        //
      },

      getDrinksCost() {
        try {
          this.drinksCost = this.currentDrinks.reduce((sum, drink) => sum + drink.quantity * drink.price, 0);
        } catch {
          this.$emit('outputMessage', this.errorMessages.unknown.message);
        }
        return this.drinksCost;
      },

      getMoneyAmount() {
        //
      },
    }
  };
</script>

<style>
</style>