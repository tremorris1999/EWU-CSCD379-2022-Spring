<template>
  <v-container fluid>
    <v-row justify="center">
      <v-col>
        <v-card
          class="d-flex justify-center"
          color="transparent"
          height="120px"
          flat
        >
          <v-btn
            v-if="!display"
            block
            :disabled="disable"
            @click="showDisplay(true)"
          >
            {{ candidatesArray.length }} Available
          </v-btn>
          <v-list
            v-else
            max-height="120px"
            width="100%"
            dense
            class="overflow-y-auto"
          >
            <v-list-item
              v-for="choice in candidatesArray"
              :key="choice"
              class="justify-center"
              @click="emit(choice)"
            >
              {{ choice.toUpperCase() }}
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
    this.showDisplay(true)
  }

  showDisplay(show: boolean) {
    this.$emit('update:display', show)
  }

  mounted() {
    this.showDisplay(false)
  }
}
</script>
