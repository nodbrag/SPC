<template>
  <el-dialog
    width="600px"
    :visible.sync="visible"
    :before-close="handleModal"
    :close-on-click-modal="false"
    :close-on-press-escape="false">
    <div slot="title">{{addOrEdit === 1?'添加设备':'编辑设备'}}</div>
    <div>
      <el-form :label-position="labelPosition" label-width="90px">
        <!-- <el-form-item label="编号:" size="small">
          <el-input v-model="formData.equipmentId"></el-input>
        </el-form-item> -->
        <el-form-item label="设备编号:" size="small">
          <el-input v-model="formData.equipmentCode"></el-input>
        </el-form-item><div class="red">*</div>
        <el-form-item label="设备名称:" size="small">
          <el-input v-model="formData.equipmentName"></el-input>
        </el-form-item>
        <el-form-item label="设备分类:" size="small">
          <el-select v-model="formData.equipmentClassID">
            <el-option v-for="item in equipmentClassList" :key="item.equipmentClassID" :value="item.equipmentClassID" :label="item.equipmentClassName"></el-option>
          </el-select>
        </el-form-item><div class="red">*</div>
        <el-form-item label="设备类型:" size="small">
          <el-input v-model="formData.equipmentType"></el-input>
        </el-form-item>
        <el-form-item label="设备规格:" size="small">
          <el-input v-model="formData.equipmentSpec"></el-input>
        </el-form-item>
        <el-form-item label="设备图像:" size="small">
          <el-input v-model="formData.equipmentImage"></el-input>
        </el-form-item>
        <el-form-item label="生产厂商:" size="small">
          <el-input v-model="formData.manufacturer"></el-input>
        </el-form-item>
        <el-form-item label="投产时间" size="small">
          <el-date-picker v-model="formData.productionDate" value-format="yyyy-MM-dd">
          </el-date-picker>
        </el-form-item>
        <el-form-item label="标准容量:" size="small">
          <el-input v-model="formData.standCapacity"></el-input>
        </el-form-item>
        <el-form-item label="生命周期:" size="small">
          <el-input v-model="formData.lifeCircleYear"></el-input>
        </el-form-item>
        <el-form-item label="描述:" size="small">
          <el-input type="textarea" v-model="formData.memo"></el-input>
        </el-form-item>
      </el-form>
      <div class="sub-btn">
        <el-button type="primary" @click="handleModal(true, addOrEdit)">保存</el-button>
      </div>
    </div>
    <!-- <div slot="footer" class="detail-wrap-bottom">
      <el-button type="default" @click="handleModal(false, addOrEdit)">取消</el-button>
      <el-button type="primary" @click="handleModal(true, addOrEdit)">保存</el-button>
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
        labelPosition: 'left',
        equipmentClassList:[{equipmentClassID:'111',equipmentClassName:'13'}],
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