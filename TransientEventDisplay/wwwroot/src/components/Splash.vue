<template>
  <div class="container body-content">

    <div id="app">
      <div class="hello">
        <h1>{{ msg }}</h1>
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
    msg: 'Transient Event Display'
    }
    },
    components: {
    'app-footer': Footer
    },
    created () {
    }
    }
</script>