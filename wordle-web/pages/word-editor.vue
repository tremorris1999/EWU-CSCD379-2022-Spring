<template>
    <v-container>
        <v-row justify="center" class="my-4">
            <v-btn
                color="primary"
                nuxt
                to="/"
                fab
                x-small
            >
                <v-icon>mdi-home</v-icon>
            </v-btn>   
        </v-row>

        <v-row justify="center">
            <v-col cols="8">
                <v-card>
                    <v-card-title class="justify-center">Word Editor</v-card-title>
                    <!-- <SearchBar :wordList="this.wordList" v-bind="results" @update="update" />-->
                    <v-row justify="center" v-for="r in this.results" :key="r">
                        <v-col cols="6">
                            {{r}}
                        </v-col>
                        <v-col cols="2" />
                        <v-col cols="1">
                            <v-btn fab x-small>
                                <v-icon>
                                    mdi-delete-forever
                                </v-icon>
                            </v-btn>
                        </v-col>
                    </v-row>
                </v-card>
            </v-col>
        </v-row>

        <v-row justify="center">
            <v-btn fill color="primary">
                Add Word
            </v-btn>
        </v-row>

    </v-container>
</template>

<script lang="ts">
import {Component, Vue} from 'vue-property-decorator'

@Component
export default class WordEditor extends Vue{
    wordList: string[] = [
        "apple",
        "avent",
        "banjo",
        "brick",
        "caulk",
        "donut",
        "greet",
        "joker",
        "lemur",
        "young",
        "zebra"
        ]
    // TODO: remove hardcoded list
    results: string[] = this.wordList

    created()
    {
        this.refresh()
    }

    update(results: string[])
    {
        this.results = results;
    }

    refresh()
    {
        this.$axios.get("/api/Words")
            .then((response) =>
            {
                //this.wordList = response.data
            })
    }

    addWord(word: string)
    {
        this.$axios.post("/api/Words/add", {value: word});
        this.refresh()
    }

    removeWord(word: string)
    {
        this.$axios.delete("/api/Words/delete")
    }
}
</script>