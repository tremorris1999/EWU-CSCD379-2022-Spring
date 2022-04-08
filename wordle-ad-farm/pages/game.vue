<template>
    <v-card class='eyeball monetization'> 
        <NuxtLogo />
        <VuetifyLogo />
        <v-card-text>
            <p style="h1"> 
                enjoy some ads!
            </p>            
            <v-btn color="primary" nuxt to="/" loading={{waitASec}} > 
            <!-- index.vue is implicit, so only route to / -->
                home page
            </v-btn>
        </v-card-text>
           
<!-- 3. Create a simple page called game.vue ✅
   - Page should have a card with a heading that with a clever name for the game ✅
   - some default placeholder body text ✅
   - and a button to take you back to the home page ✅
   - there should be a button the home page to access this page ✅ -->
    

    </v-card>
</template>

<script lang="ts" src="../scripts/wordsService.ts"></script>