<template>
  <div>
    <h2 class="display-5 text-center mt-5">Add Drinks</h2>
    <table class="table table-bordered text-center">
      <thead class="table-dark">
        <tr class="h4">
          <th class="col-1">Select Drink</th>
          <th class="col-1">Enter Quantity</th>
          <th class="col-1">Action</th>
        </tr>
      </thead>
      <tbody class="table-secondary">
        <tr>
          <td>
            <select class="form-select text-center text-capitalize" v-model="selectedDrink.name">
              <option v-for="(drink, index) in totalDrinks" :key="index">
                {{ drink.name }}
              </option>
            </select>
          </td>
          <td>
            <input 
              class="form-control text-center" 
              v-model="selectedDrink.quantity"
              type="number"
              min="1"
            >
          </td>
          <td>
            <button class="btn btn-light btn-outline-dark btn-md px-5" @click="checkSelectedDrink()">
              Add
            </button>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
  export default {
    props: ['totalDrinks', 'currentDrinks', 'errorMessages'],

    data() {
      return {
        selectedDrink: { name: "", quantity: 1 },
      };
    },

    methods: {
      checkSelectedDrink() {
        try {
          let totalDrink = this.totalDrinks.find((drink) => drink.name === this.selectedDrink.name);
          let currentDrink = this.currentDrinks.find((drink) => drink.name === this.selectedDrink.name);
          if (totalDrink === undefined) {
            throw (this.errorMessages.drinkName);
          }
          let currentDrinkQuantity = (currentDrink === undefined) ? 0 : currentDrink.quantity;
          let totalDrinkStock = totalDrink.stock;
          if (currentDrinkQuantity + this.selectedDrink.quantity > totalDrinkStock) {
            throw (this.errorMessages.aboveDrinkQuantity);
          }
          if (this.selectedDrink.quantity < 1) {
            throw (this.errorMessages.belowDrinkQuantity);
          }
          this.$emit('addDrinks', this.selectedDrink);
        } catch(error) {
          if (error.expected) {
            this.$emit('outputMessage', error.message);
          } else {
            this.$emit('outputMessage', this.errorMessages.unknown.message);
          }
        }
      },
    },
  };
</script>

<style>
</style>