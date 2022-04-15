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
