<template>
<div class = "container">
  <table class="table" id="sortTable">
    <thead>
      <tr>
        <th>Name</th>
        <th>Description</th>
        <th>Release Year</th>
      </tr>
    </thead>
    <tbody>
      <tr class = "motion-picture-row" v-for="MP in MotionPictures" v-bind:key ="MP.id">
        <td>{{MP.name}}</td>
        <td>{{MP.description}}</td>
        <td>{{MP.releaseYear}}</td>
      </tr>
    </tbody>
  </table>
</div>
<div class = "b-table-container">
  <b-table striped hover : items = "MotionPictures"></b-table>
</div>
</template>



<script>
import MotionPictureService from "../Service/MotionPictureService.js";
// $('#sortTable').DataTable();
import { BTable } from 'bootstrap-vue'

export default {
  data() {
    return {
      MotionPictures: [],
    };
  },
  created() {
    MotionPictureService.getAllMotionPictures().then((response) => {
      this.MotionPictures = response.data;
    });
  },
};
</script>

<style>
</style>