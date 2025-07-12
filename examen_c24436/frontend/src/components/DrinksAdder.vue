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
</script>

<style>
</style>