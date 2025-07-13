<template>
  <div>
    <h2 class="display-5 text-center mt-5">Available Drinks</h2>
    <table class="table table-bordered text-center">
      <thead class="table-dark">
        <tr class="h4">
          <th class="col-1">Name</th>
          <th class="col-1">Price</th>
          <th class="col-1">Quantity</th>
        </tr>
      </thead>
      <tbody class="table-secondary text-capitalize">
        <tr v-for="(drink, index) in drinks" :key="index">
          <td>{{ drink.name }}</td>
          <td>{{ cashSymbol }}{{ drink.price }}</td>
          <td>{{ drink.quantity }}</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
  export default {
    props: ['drinks', 'cashSymbol'],
  };
</script>

<style>
</style>