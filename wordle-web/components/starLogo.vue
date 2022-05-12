<template>
  <v-icon class="star-logo" color="yellow" size="150">mdi-star</v-icon>
</template>

<style>
.star-logo {
  max-height: 180px;
  max-width: 200px;
  transform: rotateY(1400deg);
  animation: turn 2.5s ease-out forwards 0.5s;
}

@keyframes turn {
  100% {
    transform: rotateY(0deg);
  }
}
</style>