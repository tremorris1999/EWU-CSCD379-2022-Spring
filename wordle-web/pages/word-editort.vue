<template>
<v-container>
    <v-card>
        <v-card-title class="justify-center">
            Word Editor
        </v-card-title>
        <v-row justify="center">
            <v-col cols="8">
    <v-text-field placeholder="Search..." 
    v-model="query"/>
            </v-col>
        </v-row>
    <v-row
    v-for="w in this.pageContent" :key="w"
    >
    <v-col cols="1" />
    <v-col cols="3">
    {{ w.toUpperCase() }}
    </v-col>
    
    <v-col cols="3">
        <v-btn @click="editWord(w, true)">
            Make Common
        </v-btn>
    </v-col>
    <v-col cols="3">
        <v-btn @click="editWord(w, false)">
            Make Uncommon
        </v-btn>
    </v-col>
    <v-col cols="2">
        <v-btn color="info" @click="deleteWord(w)">
            Delete
        </v-btn>
    </v-col>
    </v-row>
    <v-card-actions>
        <v-pagination v-model="currentPage" :length="numPages" @input="goToPage"/>
    </v-card-actions>
    </v-card>
</v-container>
</template>

<script lang="ts">
import { Component, Vue, Watch } from 'vue-property-decorator'

@Component
export default class WordEditor extends Vue
{
    pageSize: number = 25
    currentPage: number = 0
    wordlist: string[] = []
    results: string[] = []
    pageContent: string[] = []
    query: string = ""
    loading: boolean = true;
    numPages: number = 0

    created(){
        this.$watch('query', (newQuery) => {
            this.results = this.wordlist.filter(item => item.startsWith(newQuery))
            this.numPages = Math.round(this.results.length / this.pageSize)
            this.goToPage(1)
        })
    }

    mounted()
    {
        
        this.$axios
            .get("/api/Word/Get")
            .then((response) => {
                this.wordlist = response.data
                this.results = this.wordlist
                this.numPages = Math.round(this.results.length / this.pageSize)
                this.goToPage(1)
                this.loading = false;
            })
    }

    goToPage(index: number)
    {
        console.log("\r\n Page " + index)
        this.currentPage = index
        this.pageContent = this.results.slice((index - 1) * this.pageSize, index * this.pageSize)
    }

    addWord(value: string, common: boolean)
    {
        this.$axios
            .post('/api/Word/Add', {
            value: value,
            common: common
            })
            .then((response) => {
                // dialog maybe?
                this.query = ""
            })
    }

    editWord(value: string, common: boolean)
    {
        this.$axios
            .put('/api/Word/ChangeCommon', {
                value: value,
                common: common
            })
            .then((response) => {
                // dialog maybe?
                this.query = ""
            })
    }

    deleteWord(value: string)
    {
        this.$axios
            .put('/api/Word/Delete', {
                value: value,
                common: true
            })
            .then((response) => {
                // dialog maybe?
                this.query = ""
            })
    }

    
}
</script>