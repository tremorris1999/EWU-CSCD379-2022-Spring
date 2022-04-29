<template>
  <v-container fluid>
    <v-row justify="center">
      <v-col>
        <v-card
          class="d-flex justify-center"
          color="transparent"
          height="120px"
        >
          <v-btn v-if="!display" block :disabled="disable" @click="show">
            {{ candidatesArray.length }} Available
          </v-btn>
          <v-list
            v-if="display"
            max-height="120px"
            width="100%"
            dense
            class="overflow-y-auto"
          >
            <v-list-item
              v-for="c in candidatesArray"
              :key="c"
              class="justify-center"
              @click="emit(c)"
            >
              {{ c.toUpperCase() }}
            </v-list-item>
          </v-list>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>

<script lang="ts">
import { Component, Prop, Vue } from 'vue-property-decorator'

@Component
export default class CandidateDisplay extends Vue {
  @Prop({ required: true })
  candidatesArray!: string[]

  @Prop({ required: true })
  display!: boolean

  @Prop({ required: true })
  disable!: boolean

  emit(c: string) {
    this.$emit('fill-word', c)
    this.hide()
  }

  show() {
    this.display = true
  }

  hide() {
    this.display = false
  }

  mounted() {
    this.hide()
  }
}
</script>
