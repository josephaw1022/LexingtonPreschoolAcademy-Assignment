<script setup lang="ts">
import { provide } from 'vue';
import { listOfAllClasses } from './DTO/Classes';
import { HttpService } from './api';


const httpService = HttpService.getInstance

// Injections for our vue components
provide('allClasses', listOfAllClasses);
provide('httpService', httpService);


</script>

<template>
  <v-app>
    <RouterView></RouterView>
  </v-app>
</template>

<style scoped>
:root {
  width: 100%;
  height: 100%;
  padding: 0;
  margin: 0;
}


html,
body,
#app {
  width: 100%;
  height: 100%;
  padding: 0;
  margin: 0;
}
</style>
