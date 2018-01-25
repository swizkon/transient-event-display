<template>
  <div class="container body-content">

    <div id="app">
      <div class="hello">
        <h1>{{ msg }}</h1>
        <h2>{{ info }}</h2>
      </div>
      <router-view></router-view>
    </div>

    <app-footer></app-footer>
  </div>
</template>

<script>

    import Footer from '../components/Footer'

    export default {
    name: 'splash',
    data() {
    return {
    msg: 'Transient Event Display',
    info: 'Deployed w AppVeyor automatically test 2'
    }
    },
    components: {
    'app-footer': Footer
    },
    created () {
    }
    }
</script>