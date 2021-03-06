import Vue from 'vue'
import Splash from './components/Splash'
 
import "vueify/lib/insert-css"

Vue.config.productionTip = false

/* eslint-disable no-new */
new Vue({
    el: '#app',
    render: h => h(Splash),
    components: {
        Splash
    }
})