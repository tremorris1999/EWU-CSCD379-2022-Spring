<template>
  <v-icon class="star-logo" color="yellow" size="50">mdi-star</v-icon>
</template>

<style>
.star-logo {
  max-height: 100px;
  max-width: 200px;
  transform: rotateY(1400deg);
  animation: turn 5s ease-out forwards 0.5s;
  animation-duration: 30s;
}

@keyframes turn {
  100% {
    transform: rotateY(0deg);
  }
}
</style>
