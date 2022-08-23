<template>
  <div id="app">
    <h1 class="header">Motion Pictures</h1>

    <button
      type="button"
      class="btn btn-primary add"
      v-on:click="showForm = true"
      v-show="!showForm"
    >
      Add +
    </button>
    <br />

    <!-- FORM -->
    <div class="form" v-show="showForm">
      <h3 class="form-head">
        {{
          edit == true
            ? "You can update motion picture information: "
            : "Add information of the motion picture: "
        }}
      </h3>
      <form class="create">
        <label for="name">Name: </label>
        <input
          id="add-name"
          :class="'validName'"
          type="text"
          name="name"
          v-model="motionPicture.name"
        />
        <label for="name">Description: </label>
        <input
          id="add-description"
          :class="'validDescription'"
          type="text"
          name="description"
          v-model="motionPicture.description"
        />
        <label for="name">Release Year: </label>
        <input
          id="add-year"
          :class="'validYear'"
          type="text"
          name="releaseYear"
          v-model="motionPicture.releaseYear"
        />
        <div class="btn-container">
          <button
            class="save-form btn btn-primary"
            v-on:click.prevent="updateItem"
          >
            Save
          </button>
          <button class="cancel btn" v-on:click="clearForm">Cancel</button>
        </div>
      </form>
    </div>

    <div class = "delete-warning" v-if ="warn">
      <h4>Are you sure you want to delete that?</h4>
      <button
            class="confirm btn btn-primary"
            v-on:click.prevent="deleteItem"
          >
            Delete
          </button>
          <button class="cancel-delete btn" v-on:click="warn=false">Cancel</button>
    </div>

    <!-- TABLE -->

    <b-table
      class="table"
      striped
      hover
      :items="MotionPictures"
      :fields="fields"
      v-show="!showForm"
    >
      <template #cell(actions)="data">
        <b-button
          @click="
            (showForm = true),
              (edit = true),
              (motionPicture.id = MotionPictures[data.index].id)
          "
          ><i class="fa-solid fa-pen-to-square"></i
        ></b-button>
        <b-button @click="onRowClicked(data.index), (showForm = true)"
          ><i class="fa-solid fa-clone"></i
        ></b-button>
        <b-button
          @click="
            (warn = true),(toDelete = MotionPictures[data.index].id)
          "
          ><i class="fa-solid fa-trash-can"></i
        ></b-button>
      </template>
    </b-table>
  </div>
</template>

<script>
import { BTable } from "bootstrap-vue";
import MotionPictureService from "./Service/MotionPictureService.js";

export default {
  name: "App",
  components: {
    BTable,
  },
  data() {
    return {
      motionPicture: {
        name: "",
        description: "",
        releaseYear: "",
      },
      showForm: false,
      edit: false,
      validName: true,
      validDescription: true,
      validYear: true,
      warn: false,
      toDelete:0,
      fields: [
        {
          key: "id",
          sortable: true,
        },
        {
          key: "name",
          sortable: true,
        },
        {
          key: "description",
          sortable: false,
        },
        {
          key: "releaseYear",
          label: "Release Year",
          sortable: true,
        },
        {
          key: "actions",
          label: "Actions",
        },
      ],
      MotionPictures: [],
    };
  },
  created() {
    MotionPictureService.getAllMotionPictures().then(
      (response) => (this.MotionPictures = response.data)
    );
  },
  methods: {
    updateItem() {
      this.validate();
      this.motionPicture.releaseYear = parseInt(this.motionPicture.releaseYear);

      if (
        this.validDescription === true &&
        this.validName === true &&
        this.validYear === true
      ) {
        if (!this.edit) {
          MotionPictureService.addMotionPicture(this.motionPicture).then(
            (this.showForm = false)
          );
          this.clearForm();
          alert("Saved successfully");
        } else {
          MotionPictureService.updateMotionPicture(this.motionPicture).then(
            (this.showForm = false)
          );
          this.clearForm();
          alert("Updated successfully");
        }
        document.location.reload();
      }

      return true;
    },
    deleteItem() {
      MotionPictureService.deleteMotionPicture(this.toDelete);
      document.location.reload();
    },
    clearForm() {
      this.validYear = true;
      this.validName = true;
      this.validDescription = true;
      this.motionPicture = {
        name: "",
        releaseYear: 0,
        description: "",
      };
    },
    onRowClicked(index) {
      this.motionPicture = this.MotionPictures[index];
    },
    validate() {
      if (
        this.motionPicture.name.length === 0 ||
        this.motionPicture.name.length > 50
      ) {
        this.validName = "invalid-name";
        alert("Name must be between 1 and 50 characters");
        document.getElementById("add-name").style.border = "solid 1px red";
      } else {
        this.validName = true;
      }
      if (this.motionPicture.description.length > 500) {
        this.validDescription = "invalid-description";
        alert("Description cannot be more than 500 characters");
        document.getElementById("add-description").style.border = "solid 1px red";
      } else {
        this.validDescription = true;
      }
      if (
        this.motionPicture.releaseYear.length>=5 || this.motionPicture.releaseYear.length<=3
      ) {
        this.validYear = "invalid-year";
        alert("Release year must be a four digit year");
        document.getElementById("add-year").style.border = "solid 1px red";
      } else {
        this.validYear = true;
      }
    },
  },
};
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}

.create {
  display: flex;
  flex-direction: column;
  width: 50%;
  margin: auto;
}

.btn-container {
  margin-top: 10px;
}

.add {
  position: absolute;
  left: 84.5%;
}

.table {
  margin-top: 10px;
}

.invalid-name {
  box-shadow: 0 0 3px #cc0000;
}

.invalid-description {
  box-shadow: 0 0 3px #cc0000;
}

.invalid-year {
  box-shadow: 0 0 3px #cc0000;
}
</style>
