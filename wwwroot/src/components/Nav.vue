<template lang="pug">
    nav.navbar.navbar-inverse.navbar-fixed-top
        .container
            .navbar-header
                a.navbar-brand(href='/index.html') Transient Event Display
</template>

<script>
  module.exports = {
    name: 'app-nav',
    data() {
      return {
        copyright: '2017 - swizkon'
      }
    }
  }
</script>