<template>
  <h2 class="display-5 text-center mt-5">Output Panel</h2>
  <table class="table table-bordered text-center">
    <thead class="table-dark">
      <tr class="h4">
        <th class="col-1"></th>
      </tr>
    </thead>
    <tbody class="table-secondary">
      <tr>
        <td class="align-middle">
          <div class="container align-top text-center" v-if="showChange">
            <h5 class="text-center mb-4">
              {{ successMessages.finalizingPurchase }}
            </h5>
            <h5 class="text-center text-capitalize">
              Total Change: {{ cashSymbol }}{{ informationMessage.totalChange }}
            </h5>
            <div class="d-flex flex-wrap bg-dark text-white text-center py-2">
              <div class="flex-fill">Type</div>
              <div class="flex-fill">Quantity</div>
              <div class="flex-fill">Total</div>
            </div>
            <div class="d-flex flex-wrap text-capitalize text-center py-4" v-for="(change, index) in informationMessage.detailedChange" :key="index">
              <div class="flex-fill">{{ cashSymbol }}{{ change.type }}</div>
              <div class="flex-fill">{{ change.quantity }}</div>
              <div class="flex-fill">{{ cashSymbol }}{{ change.quantity * change.type }}</div>
            </div>
          </div>
          <div class="container align-top text-center" v-else>
            <p class="text-center">{{ informationMessage }}</p>
          </div>
        </td>
      </tr>
    </tbody>
  </table>
</template>

<script>
  export default {
    props: ['cashSymbol', 'informationMessage', 'showChange', 'successMessages'],

    data() {
      return {
      };
    },

    methods: {
    },
  };
</script>

<style>
</style>