<template lang="pug">
 .footer
    hr
    footer
        p {{copyright}}
</template>

<script>
    module.exports = {
    name: 'app-footer',
    data() {
    return {
    copyright: 'Transient Event Display'
    }
    }
    }
</script>