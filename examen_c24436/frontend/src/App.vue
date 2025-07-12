<template>
  <div id="app">
    <router-view />
  </div>
</template>

<script>
  export default {
    name: 'App',
  }
</script>

<style>
  @font-face {
    font-family: ProtestGuerrilla;
    src: url('~@/assets/fonts/ProtestGuerrilla.ttf')
  }

  #app {
    font-family: ProtestGuerrilla;
  }
</style>
