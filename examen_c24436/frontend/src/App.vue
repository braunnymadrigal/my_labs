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
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: #2c3e50;
    margin-top: 60px;
  }
</style>
