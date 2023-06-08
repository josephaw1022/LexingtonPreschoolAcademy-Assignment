<template>
    <main className="h-full w-full flex flex-col">

        <VAppBar scrollBehavior="hide" class="static border-b-2 s" elevation="0">
            <VAppBarTitle>
                Student List
            </VAppBarTitle>
            <VSpacer></VSpacer>
            <VBtn to="/create-student" color="info" variant="tonal">
                Create Student
            </VBtn>
        </VAppBar>


        <LoadingSpinner v-if="isLoading"></LoadingSpinner>

        <v-table class="h-full w-full " v-else>
            <thead>
                <tr>
                    <th class="text-left text-xl ">
                        First Name
                    </th>
                    <th class="text-left text-xl">
                        Last Name
                    </th>
                    <th class="text-left text-xl">
                        Classes
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="(item, index) in studentList" :key="index">
                    <td>{{ item.firstName }}</td>
                    <td>{{ item.lastName }}</td>
                    <td>
                        <span v-for="(studentClass, index2) in item.classes" v-if="!!item.classes.length" :key="index2">
                            {{ studentClass }}
                            {{ index2 < item.classes.length - 1 ? ', ' : '' }} </span>
                    </td>
                </tr>
            </tbody>
        </v-table>
    </main>
</template>


<script lang="ts" setup>
import { ref } from 'vue';
import type { CreateStudent } from '../DTO/CreateStudent';
import LoadingSpinner from '../components/LoadingSpinner.vue';


const initialStudents: CreateStudent[] = [
    {
        firstName: 'John',
        lastName: 'Doe',
        classes: ['Math', 'Science', 'English'],
    },
    {
        firstName: 'Jane',
        lastName: 'Doe',
        classes: ['Math', 'Science', 'English'],
    }
]

const studentList = ref<CreateStudent[]>(initialStudents);


const isLoading = ref(false);



</script>



<style scoped>
:root {
    width: 100%;
    height: 100%;
}
</style>
```