<script lang="ts" setup>
import { inject, ref } from 'vue';
import type { CreateStudent } from '../DTO/CreateStudent';
import LoadingSpinner from '../components/LoadingSpinner.vue';
import { HttpService } from '../api';
import { onMounted } from 'vue';


const httpService = inject('httpService', HttpService.getInstance) as HttpService;


const studentList = ref<CreateStudent[]>([]);
const isLoading = ref(true);
const errorOccurred = ref(false);


async function getStudents() {
    isLoading.value = true;
    const { data, error, status } = await httpService.get<{
        dataset: CreateStudent[],
        count: number
    }>('/student');

    if (!!error) {
        errorOccurred.value = true;
    }

    if (!!data) {
        const { dataset, count } = data

        studentList.value = dataset.map((item: any) => {
            const tempItem = item;
            let tempItemClasses = [];

            tempItemClasses = tempItem.classes?.map((classObject: { [x: string]: any; }) => {
                const tempClasses = [];

                console.log(classObject);

                const classNumber = classObject['class']
                switch (classNumber) {
                    case 0:
                        tempClasses.push('Math');
                        break;
                    case 1:
                        tempClasses.push('Art');
                        break;
                    case 2:
                        tempClasses.push('Science');
                        break;
                    case 3:
                        tempClasses.push('History');
                        break;
                    case 4:
                        tempClasses.push('Spanish');
                        break;
                    case 5:
                        tempClasses.push('PE');
                        break;
                }

                return tempClasses;
            })

            tempItem.classes = tempItemClasses;

            return tempItem;
        })


    }

    // studentList.value = response.data;
    isLoading.value = false;
}


onMounted(async () => {
    await getStudents();
});




</script>


<template>
    <main className="h-full w-full flex flex-col">

        <VAppBar scrollBehavior="hide" class="sticky border-b-2 " elevation="0">
            <VAppBarTitle>
                Student List
            </VAppBarTitle>
            <VSpacer></VSpacer>
            <VBtn to="/create-student" color="info" variant="tonal">
                Create Student
            </VBtn>
        </VAppBar>

        <VContainer class="h-full w-full grid place-items-center overflow-y-scroll " v-if="isLoading">
            <LoadingSpinner></LoadingSpinner>
        </VContainer>

        <VContainer class="h-full w-full grid place-items-center" v-else-if="errorOccurred">
            <v-typography class="text-center text-red-400 text-xl">
                An error occurred while loading the student list.
            </v-typography>
        </VContainer>

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
                            {{ String(studentClass) }}
                            {{ index2 < item.classes.length - 1 ? ', ' : '' }} </span>
                    </td>
                </tr>
            </tbody>
        </v-table>
    </main>
</template>





<style scoped>
:root {
    width: 100%;
    height: 100%;
}
</style>
```