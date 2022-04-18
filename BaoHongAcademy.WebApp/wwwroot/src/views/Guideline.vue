<template>
  <div id="baohong-guideline" class="p-4">
    <h1>Guideline</h1>

    <h3>Dropdown</h3>
    <div class="dropdown">
      <button
        class="btn btn-secondary dropdown-toggle"
        type="button"
        id="dropdownMenuButton"
        data-toggle="dropdown"
        aria-haspopup="true"
        aria-expanded="false"
      >
        Dropdown button
      </button>
      <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
        <a class="dropdown-item" href="#">Action</a>
        <a class="dropdown-item" href="#">Another action</a>
        <a class="dropdown-item" href="#">Something else here</a>
      </div>
    </div>
    <p>
      ------------------------------------------------------------------------------------
    </p>

    <h3>Base Input</h3>
    <input type="text" />
    <p>
      ------------------------------------------------------------------------------------
    </p>

    <h3>VeeValidate</h3>
    <div class="ml-3">
      <p><b> Input validate</b></p>
      <Form @submit="onSubmit">
        <Field name="email" type="email" :rules="required" />
        <button class="ml-2 h-btn h-btn-primary">Sign up</button>
        <ErrorMessage name="email" />
      </Form>
    </div>
    <p>
      ------------------------------------------------------------------------------------
    </p>

    <h3>Toastification</h3>
    <button v-on="showToast">Show toast</button>
    <p>
      ------------------------------------------------------------------------------------
    </p>

    <h3>Font Awesome</h3>
    <div>
      <span class="mr-2"><em>HTML</em></span>
      <i class="fa fa-spinner fa-spin"></i>
    </div>
    <div>
      <span class="mr-2"><em>VueJS</em></span>
      <font-awesome-icon icon="coffee" />
    </div>
    <p>
      ------------------------------------------------------------------------------------
    </p>

    <h3>Font Awesome</h3>
    <button type="button" class="btn btn-primary">Primary</button>
    <button type="button" class="btn btn-secondary">Secondary</button>
    <button type="button" class="btn btn-success">Success</button>
    <button type="button" class="btn btn-danger">Danger</button>
    <button type="button" class="btn btn-warning">Warning</button>
    <button type="button" class="btn btn-info">Info</button>
    <button type="button" class="btn btn-light">Light</button>
    <button type="button" class="btn btn-dark">Dark</button>
    <p>
      ------------------------------------------------------------------------------------
    </p>

    <h3>Element Plus (main library) v1.1.0-beta.1</h3>
    <h5>Button</h5>
    <el-row>
      <el-button plain disabled>Plain</el-button>
      <el-button type="primary" plain>Primary</el-button>
      <el-button type="success" plain>Success</el-button>
      <el-button type="info" plain>Info</el-button>
      <el-button type="warning" plain>Warning</el-button>
      <el-button type="danger" plain>Danger</el-button>
    </el-row>
    <h5>Button disbled</h5>
    <el-row>
      <el-button plain disabled>Plain</el-button>
      <el-button type="primary" plain disabled>Primary</el-button>
      <el-button type="success" plain disabled>Success</el-button>
      <el-button type="info" plain disabled>Info</el-button>
      <el-button type="warning" plain disabled>Warning</el-button>
      <el-button type="danger" plain disabled>Danger</el-button>
    </el-row>
    <h5>Dialog</h5>
    <el-button type="text" @click="dialogVisible = true"
      >click to open the Dialog</el-button
    >
    <el-dialog
      v-model="dialogVisible"
      title="Tips"
      width="30%"
      :before-close="handleClose"
    >
      <span>This is a message</span>
      <template #footer>
        <span class="dialog-footer">
          <el-button @click="dialogVisible = false">Cancel</el-button>
          <el-button type="primary" @click="dialogVisible = false"
            >Confirm</el-button
          >
        </span>
      </template>
    </el-dialog>
    <p>
      ------------------------------------------------------------------------------------
    </p>

    <h3>HDialog</h3>
    <el-button type="text" @click="isOpenHDialog = true"
      >Open HDialog</el-button
    >
    <HDialog
      :isOpenDialog="isOpenHDialog"
      title="Tạo khóa học"
      v-on:close-dialog="isOpenHDialog = false"
    >
      <h2>Abc</h2>
      <h2>Abc</h2>
      <template v-slot:dialog-footer>
        <el-button @click="isOpenHDialog = false">Cancel 123</el-button>
        <el-button @click="isOpenHDialog = false" type="primary">Confirm 12</el-button>
      </template>
    </HDialog>
  </div>
</template>
<script>
// import $ from "jquery";
import { Form, Field, ErrorMessage } from "vee-validate";
import { validateEmail } from "@/helpers/validation.js";
// import { required, email, min } from "@vee-validate/rules";
// defineRule("required", required);
// defineRule("email", email);
// defineRule("min", min);
import HDialog from "@/components/HDialog";

export default {
  components: {
    Form,
    Field,
    ErrorMessage,
    HDialog,
  },
  data() {
    return {
      dialogVisible: false,
      isOpenHDialog: false,
    };
  },
  methods: {
    onSubmit(values) {
      console.log(values, null, 2);
    },
    showToast() {
      this.$notify({
        type: "success", // warn, error, success
        title: "Important message",
        text: "Hello user!",
      });
    },
    validateEmail(value) {
      return validateEmail(value);
    },
  },
};
</script>
<style lang="scss">
#baohong-guideline {
  height: 100vh;
  overflow: auto;
}
</style>
