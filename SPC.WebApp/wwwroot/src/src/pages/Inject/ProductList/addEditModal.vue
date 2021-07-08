<template>
  <el-dialog
    width="600px"
    :visible.sync="visible"
    :before-close="handleModal"
    :close-on-click-modal="false"
    :close-on-press-escape="false">
    <div slot="title">{{addOrEdit === 1?'添加产品':'编辑产品'}}</div>
    <div>
      <el-form :label-position="labelPosition" label-width="90px">
        <el-form-item label="产品编号:" size="small">
          <el-input v-model="formData.productCode"></el-input>
        </el-form-item><div class="red">*</div>
        <el-form-item label="产品名称:" size="small">
          <el-input v-model="formData.productName"></el-input>
        </el-form-item><div class="red">*</div>
      </el-form>
      <div class="sub-btn">
        <el-button @click="handleModal(true, addOrEdit)">保存</el-button>
      </div>
    </div>
    <!-- <div slot="footer" class="detail-wrap-bottom">
      <el-button type="default" @click="handleModal(false, addOrEdit)">取消</el-button>
      <el-button type="primary" @click="handleModal(true, addOrEdit)">确认</el-button>
    </div> -->
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