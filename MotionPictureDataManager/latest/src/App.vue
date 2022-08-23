<template>
  <header></header>
  <motion-picture-table></motion-picture-table>

</template>

<script setup>
import MotionPictureTable from "./components/MotionPictureTable.vue";


</script>

<style scoped>


@media (min-width: 1024px) {
  header {
    display: flex;
    place-items: center;
    padding-right: calc(var(--section-gap) / 2);
  }

  .logo {
    margin: 0 2rem 0 0;
  }

  header .wrapper {
    display: flex;
    place-items: flex-start;
    flex-wrap: wrap;
  }
}
</style>
