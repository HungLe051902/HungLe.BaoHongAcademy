<template>
  <div id="login" class="d-flex align-items-center flex-column">
    <Brand />
    <p class="fs20p">Đăng nhập vào BaoHongAcademy</p>
    <div class="login-form">
      <!-- <Form> -->
      <div class="form-group">
        <label for="exampleInputEmail1">Email address</label>
        <input
          @keyup.enter="login"
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
          @keyup.enter="login"
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
      <button v-on:click="login" class="mt-2 h-btn h-btn-primary w-100 button-load">
        <span v-if="isLoadingBtn == 1"><i class="fa fa-spinner fa-spin mr-2"></i></span>
        Đăng nhập
      </button>
      <div class="d-flex">
        <button v-on:click="loginByGoogle" class="h-btn h-btn-primary mt-3 w-50">
          <i class="fa-brands fa-google mr-1"></i>
          Tiếp tục với Google
        </button>
        <button v-on:click="loginByFacebook" class="ml-2 h-btn h-btn-primary mt-3 w-50">
          <span class="mr-1"><i class="fa-brands fa-facebook-square"></i></span>
          Tiếp tục với Facebook
        </button>
      </div>
      <div class="mt-3 center-content flex-column">
        <p class="mb-2">
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
import Brand from "@/components/HBrand";
import AccountMixin from "@/mixins/accountMixin.vue";
import { HTTP } from "@/services/BaseAxios";
import AccountService from "@/services/accountService.js";
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
      isLoadingBtn: 0,
    };
  },
  created() {},
  methods: {
    loginByFacebook() {
      this.$notify({
        type: "info", // warn, error, success
        title: "Thông báo",
        text: "Tính năng đang phát triển",
      });
    },
    async loginByGoogle() {
      /**
       * Token: this.$gAuth.instance.currentUser.get().getAuthResponse()
       * getAuthResponsethis.googleUser.getAuthResponse()
       */
      const googleUser = await this.$gAuth.signIn();
      var gmail = googleUser.getBasicProfile().getEmail();

      var res = await AccountService.externalLogin({ Gmail: gmail });
      if (res?.data?.Success) {
        this.$notify({
          type: "success", // warn, error, success
          title: "Thành công",
          text: "Đăng nhập thành công",
        });
        // Save token to local storage
        saveToken(res.data.Data);

        this.$router.push({ path: "main", query: { isReload: true } });
      }
    },
    login() {
      const that = this;
      try {
        this.onSubmit();
        if (this.metaValidation.valid == false) {
          return;
        }

        this.isLoadingBtn = 1;
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
              this.$router.push({ path: "main", query: { isReload: true } });
            } else {
              this.$notify({
                type: "error", // warn, error, success
                title: "Cảnh báo",
                text: "Bạn nhập sai tài khoản hoặc mật khẩu",
              });
              this.isLoadingBtn = 0;
            }
          })
          .catch((err) => {
            console.log(err);
            that.isLoadingBtn = 0;
          });
      } catch (error) {
        console.log();
        that.isLoadingBtn = 0;
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
