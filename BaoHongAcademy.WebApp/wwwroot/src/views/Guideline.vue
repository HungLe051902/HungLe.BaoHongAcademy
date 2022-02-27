<template>
  <div class="m-4">
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

export default {
  components: {
    Form,
    Field,
    ErrorMessage,
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
<style lang="scss"></style>
