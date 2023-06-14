<script lang="ts" setup>
import { inject } from 'vue';
import { ref } from 'vue';
import LoadingSpinner from '../components/LoadingSpinner.vue';
import { HttpService } from '../api';
import { useRouter } from 'vue-router';

const router = useRouter();

const allClasses = inject('allClasses');
const httpService = inject('httpService', HttpService.getInstance) as HttpService;

const isLoading = ref(false);
const firstName = ref("");
const lastName = ref("");
const classSelections = ref([]);



const createStudent = async () => {

  isLoading.value = true;

  const student = {
    firstName: firstName.value,
    lastName: lastName.value,
    classes: classSelections.value,
  };


  const { data, error, status } = await httpService.post('/student', student);


  if (!!error) {
    console.log(error);
  }


  if (!!data) {
    router.push('/');
  }
}

</script>


<template>
  <VAppBar class="static">
    <VToolbarTitle>
      <RouterLink to="/">
        <VBtn variant="tonal" color="info" size="large" class="text-center">
          Go Back
        </VBtn>
      </RouterLink>
      <VTypography class="text-center ml-5">Create Student</VTypography>
    </VToolbarTitle>

    <VSpacer></VSpacer>
    <VBtn @click="createStudent" :disabled="isLoading" variant="tonal" color="info" class="text-center" size="large">
      Create</VBtn>
  </VAppBar>
  <VContainer class="h-full w-full mt-10" v-if="!isLoading">

    <VRow>
      <VCol>
        <VTextField label="First Name" v-model="firstName"></VTextField>
      </VCol>
      <VCol>
        <VTextField label="Last Name" v-model="lastName"></VTextField>
      </VCol>
    </VRow>
    <VRow>
      <VCol>
        <v-select v-model="classSelections" :items="allClasses" label="Select" multiple hint="Pick the students classes"
          persistent-hint></v-select>
      </VCol>
    </VRow>
  </VContainer>
  <VContainer class="h-full w-full grid place-items-center" v-else>
    <LoadingSpinner></LoadingSpinner>
  </VContainer>
</template>


<style scoped></style>
