<template>
  <div>
    <h2 class="display-5 text-center mt-5">Add Money</h2>
    <table class="table table-bordered text-center">
      <thead class="table-dark">
        <tr class="h4">
          <th class="col-1">Select Coin / Bill</th>
          <th class="col-1">Enter Quantity</th>
          <th class="col-1">Action</th>
        </tr>
      </thead>
      <tbody class="table-secondary">
        <tr>
          <td>
            <select class="form-select text-center" v-model="selectedMoney.type">
              <option v-for="(money, index) in supportedMoney" :key="index" :value="money">
                {{ cashSymbol }}{{ money }}
              </option>
            </select>
          </td>
          <td>
            <input 
              class="form-control text-center" 
              v-model="selectedMoney.quantity" 
              type="number"
              min="1"
            />
          </td>
          <td>
            <button class="btn btn-light btn-outline-dark btn-md px-5" @click="checkSelectedMoney()">
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
    props: ['cashSymbol', 'errorMessages'],

    data() {
      return {
        supportedMoney: [],

        selectedMoney: { type: 0, quantity: 1 },
      };
    },

    methods: {
      async getSupportedMoney() {
        try {
          const response = await this.$api.getSupportedMoney();
          this.supportedMoney = response.data;
        } catch {
          this.$emit('outputMessage', this.errorMessages.unknown.message);
        }
      },

      checkSelectedMoney() {
        try {
          if (!this.supportedMoney.includes(this.selectedMoney.type)) {
            throw (this.errorMessages.moneyType);
          }
          if (this.selectedMoney.quantity < 1) {
            throw (this.errorMessages.belowMoneyQuantity);
          }
          this.$emit('addMoney', this.selectedMoney);
        } catch(error) {
          if (error.expected) {
            this.$emit('outputMessage', error.message)
          } else {
            this.$emit('outputMessage', this.errorMessages.unknown.message);
          }
        }
      },
    },

    mounted() {
      this.getSupportedMoney();
    },
  };
</script>

<style>
</style>