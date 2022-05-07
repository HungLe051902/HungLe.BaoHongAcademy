<template>
  <div id="baohongacademy-input-search">
    <input
      :value="modelValue"
      @input="updateInput"
      :placeholder="placeholder"
      :style="inputStyles"
      type="text"
    />
  </div>
</template>
<script>
export default {
  props: {
    placeholder: {
      type: String,
    },
    modelValue: {
      type: [String, Number],
      default: "",
    },
    inputStyles: {},
  },
  methods: {
    updateInput(event) {
      this.$emit("getInput", event.target.value);
    },
  },
};
</script>
<style lang="scss"></style>
