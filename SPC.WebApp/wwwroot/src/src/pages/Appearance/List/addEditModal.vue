<template>
  <el-dialog
    width="600px"
    :visible.sync="visible"
    :before-close="handleModal"
    :close-on-click-modal="false"
    :close-on-press-escape="false">
    <!-- <div slot="title">{{addOrEdit === 1?'添加':'编辑'}}</div> -->
    <div slot="title">导入</div>
    <div>
      <el-form :label-position="labelPosition" label-width="130px">
        <el-form-item label="批号C:" size="small">
          <el-input v-model="formData.batchC"></el-input>
        </el-form-item>
        <el-form-item label="产品名称:" size="small">
          <el-input v-model="formData.productName"></el-input>
        </el-form-item>
        <el-form-item label="视觉检测机号:" size="small">
          <el-input v-model="formData.shapingMachine"></el-input>
        </el-form-item>
        <el-form-item label="检测时间:" size="small">
          <el-input v-model="formData.plasticTime"></el-input>
        </el-form-item>
        <el-form-item label="产品数量:" size="small">
          <el-input v-model="formData.productQuantity"></el-input>
        </el-form-item>
        <el-form-item label="不良数量:" size="small">
          <el-input v-model="formData.badQuantity"></el-input>
        </el-form-item>
        <el-form-item label="炉号:" size="small">
          <el-input v-model="formData.furnaceNumber"></el-input>
        </el-form-item>
      </el-form>
      <div class="sub-btn">
        <el-button @click="handleModal(true)">保存</el-button>
      </div>
    </div>
  </el-dialog>
</template>
<script>
  export default {
    props: {
      visible: {
        type: Boolean,
        default: false
      },
      formData:Object,
      addOrEdit:Number
    },
    data() {
      return {
        labelPosition: 'left'
      };
    },
    methods: {
      // isOperate 代表确认还是取消, addOrEdit代表添加还是编辑
      handleModal(isOperate, addOrEdit) {
        this.$emit('handleModal',isOperate, addOrEdit)
        // this.$emit('update:visible', false); // 直接修改父组件的属性
      }
    }
  }
</script>