<template>
  <div class="hello">
    <h1>{{ label }}</h1>
    <form v-on:submit.prevent="onSubmit">
      <input class="input-lg" name="entityid" v-model="entityId" placeholder="Enter entity id" />
    </form>
    - or select preview mock -
    <ul v-if="items">
      <li v-for="item in items">
        <a :href="'/accounts.html#/mocks/' + item">{{ item }}</a>
      </li>
    </ul>
  </div>
</template>

<script>
  import { HubConnection } from "@aspnet/signalr-client"

  var connection;

  export default {
    name: 'hello',
    data() { 
      return {
        label: `Enter item`,
        entityId: '',
        items: null
      }
    },
    created () {
        var _this = this;
            _this.items = [];

          connection = new HubConnection('/list');

          connection.on('send', data => {
              this.$toasted.success('<b>SEND </b>  ' + data);
          });

          connection.on('itemAdded', (title, list) => {
              this.$toasted.info('Added ' + title  + ' to ' + list).goAway(2000)
              this.items.push(title)
          });

          connection.on('EventPublished', (category, eventType, data) => {
              this.$toasted.info('EventPublished: ' + category + ': ' + eventType + ' ' + data).goAway(2000)
          });
          
          connection.start()
              .then(() => {
                connection.invoke('joinChannel', 'default');
                connection.invoke('send', 'Hello from HubTest.vue');
              });
    },
    methods: {
      toJSON: function(data) {
        return window['JSON'].stringify(data);
      },
        onSubmit: function (event) {
          var itemTitle = this.entityId;
          var data = {
                      "channelId": "default",
                      "eventType": "eventType",
                      "category": "category",
                      "data": "data"
                    };
          
          fetch('/api/events', {
            method: 'post',
            headers: {
              'Content-Type': 'application/json'
            },
            body: this.toJSON(data)
          }).then(function(response) {
            return response.json();
          }).then(function(data) {
            console.log('Created Gist:', data);
          });
          this.entityId = "";
        }
      }
  }
</script>