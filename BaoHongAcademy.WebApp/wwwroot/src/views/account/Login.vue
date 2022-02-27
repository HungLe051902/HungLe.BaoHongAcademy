<template>
  <div id="login" class="d-flex align-items-center flex-column">
    <Brand />
    <p class="fs20p">Đăng nhập vào BaoHongAcademy</p>
    <div class="login-form">
      <!-- <Form> -->
      <div class="form-group">
        <label for="exampleInputEmail1">Email address</label>
        <input
          ref="emailInput"
          class="form-control"
          id="exampleInputEmail1"
          aria-describedby="emailHelp"
          placeholder="Enter email"
          v-model="email"
        />
        <span class="text-danger">{{ emailError }}</span>
      </div>
      <div class="form-group">
        <label for="exampleInputPassword1">Password</label>
        <input
          type="password"
          class="form-control"
          id="exampleInputPassword1"
          placeholder="Password"
          v-model="password"
        />
        <span class="text-danger">{{ passwordError }}</span>
      </div>
      <div class="form-check">
        <input
          class="form-check-input"
          type="checkbox"
          v-model="loginKeeping"
          id="flexCheckDefault"
        />
        <label class="form-check-label" for="flexCheckDefault"> Duy trì đăng nhập </label>
      </div>
      <button v-on:click="login" class="mt-2 h-btn h-btn-primary w-100">Đăng nhập</button>
      <div class="mt-3 center-content flex-column">
        <p class="mb-3">
          Bạn chưa có tài khoản?
          <a v-on:click="goToRegister" href="#">Đăng ký</a>
        </p>
        <a href="">Quên mật khẩu?</a>
      </div>
      <!-- </Form> -->
    </div>
  </div>
</template>
<script>
import { saveToken } from "@/helpers/authenticationHelper";
import Brand from "@/components/Brand";
import AccountMixin from "@/mixins/accountMixin.vue";
import { HTTP } from "@/services/BaseAxios";
import { useField, useForm } from "vee-validate";
import * as yup from "yup";

export default {
  setup() {
    // Define a validation schema
    const schema = yup.object({
      email: yup
        .string()
        .required("Email phải được nhập")
        .email("Bạn nhập sai định dạng email"),
      password: yup
        .string()
        .required("Password phải được nhập")
        .min(8, "Password phải có ít nhất 8 ký tự"),
    });
    // Create a form context with the validation schema
    const { meta, handleSubmit } = useForm({
      validationSchema: schema,
    });
    const onSubmit = handleSubmit(() => {
      //
    });
    // No need to define rules for fields
    const { value: email, errorMessage: emailError } = useField("email");
    const { value: password, errorMessage: passwordError } = useField("password");
    return {
      metaValidation: meta,
      onSubmit,
      email,
      emailError,
      password,
      passwordError,
    };
  },
  data() {
    return {
      loginKeeping: false,
    };
  },
  created() {},
  methods: {
    login() {
      try {
        this.onSubmit();
        if (this.metaValidation.valid == false) {
          return;
        }

        HTTP.post("/Accounts/authenticate", {
          UserName: this.email,
          Password: this.password,
        })
          .then((res) => {
            if (res?.data?.Success) {
              this.$notify({
                type: "success", // warn, error, success
                title: "Thành công",
                text: "Đăng nhập thành công",
              });
              // Save token to local storage
              saveToken(res.data.Data);

              this.$router.push("/main");
            }
          })
          .catch((err) => {
            console.log(err);
          });
      } catch (error) {
        console.log();
      }
    },
  },
  mounted() {
    // Focus first tab
    var vm = this;
    this.$nextTick(function () {
      setTimeout(function () {
        vm.$refs.emailInput.focus();
      }, 100);
    });
  },
  components: {
    Brand,
    // Form,
    // Field,
  },
  mixins: [AccountMixin],
};
</script>
<style lang="scss" scoped>
#login {
  padding: 36px 0;
  background-color: $color-bg;
  height: 100vh;
  overflow: auto;
  .login-form {
    width: 500px;
    padding: 24px;
    background-color: $color-white;
    border-radius: $border-radius;
  }
}

::v-deep {
  .brand {
    color: black;
  }
}
</style>
