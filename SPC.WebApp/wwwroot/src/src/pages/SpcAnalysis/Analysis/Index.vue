<template>
  <div>
    <el-row class="warp">
      <el-col :span="24" class="warp-main box_table" v-loading="loading" element-loading-text="拼命加载中">
        <!--工具条-->
        <div class="table_tool">
          <div class="box_search">
            <el-form ref="form" :model="editForm" :inline="true" class="demo-form-inline" style="line-height:26px">
              <el-form-item><span style="font-size:14px">{{editForm.productName}}</span></el-form-item>
              <el-form-item><span style="font-size:14px">{{editForm.equipmentName}}</span></el-form-item>
              <el-form-item><span style="font-size:14px">{{editForm.BeginDateTime }}</span></el-form-item> /
              <el-form-item><span style="font-size:14px">{{editForm.EndDateTime  }}</span></el-form-item>
              <el-button type="primary" icon="el-icon-circle-plus-outline" style="float: right"  size="mini" @click="showEditDialog" >时段查询</el-button>
            </el-form>
          </div>
        </div>
        <el-row class="warp">
          <el-col :span="24">
            <el-card style="height:360px; ">
              <BadPChart ref="mychild1"  id="myChart" width="100%" height="320px"  :xAxisValue="badChart.xAxisValue" :UCLValue="badChart.ucl" :LCLValue="badChart.lcl" :CLValue="badChart.badCL" :PValue="badChart.badRate" ></BadPChart>
            </el-card>
            <el-card style="height:360px;  margin-top: 30px;">
              <OKPChart ref="mychild2" id="myChart2" width="100%" height="320px"  :xAxisValue="badChart.xAxisValue" :CLValue="badChart.okCL" :PValue="badChart.okRate" ></OKPChart>
            </el-card>
          </el-col>
        </el-row>
        <el-dialog  :visible.sync ="editFormVisible"   :before-close="closeEditDialog">
          <div slot="title">查询时段</div>
          <el-form :model="filter" label-width="120px" :rules="editFormRules" ref="editForm">
            <el-form-item label="开始时间:" prop="BeginDateTime">
            <el-date-picker v-model="filter.BeginDateTime" type="datetime" placeholder="选择日期时间">
                </el-date-picker>
            </el-form-item>
            <el-form-item label="结束时间:" prop="EndDateTime">
                <el-date-picker v-model="filter.EndDateTime" type="datetime" placeholder="选择日期时间">
                </el-date-picker>
            </el-form-item>
            <el-form-item label="检测机号:" prop="detection">
                <el-select v-model="filter.equipmentId"  placeholder="请选择">
                  <el-option
                    v-for="item in equipmentOptions"
                    :key="item.id"
                    :label="item.name"
                    :value="item.id">
                  </el-option>
                </el-select>
            </el-form-item>
            <el-form-item label="产品名称:" prop="productName">
                <el-select v-model="filter.productId"  placeholder="请选择">
                  <el-option
                    v-for="item in productOptions"
                    :key="item.id"
                    :label="item.name"
                    :value="item.id">
                  </el-option>
                </el-select>
            </el-form-item>
          </el-form>
          <div class="sub-btn">
              <el-button @click="search" :loading="loading">查询</el-button>
          </div>
        </el-dialog>
      </el-col>
    </el-row>
  </div>
</template>
<script>
  import BadControlAnalyseView from '../../../View/BadControlAnalyseView';
  export default new BadControlAnalyseView()
</script>

<style lang="stylus" scope>
  @import '../../../common/common.stylus'
</style>
<style  scoped>
.warp .el-card{
background:rgba(255,255,255,1);
box-shadow:2px 2px 4px 0px rgba(54,125,254,0.26);
border:1px solid rgba(234,234,234,1);
}
@media screen and (min-width: 1500px) { 
  .warp-main {
    height:792px;
    overflow: overlay;
    margin-top: 0.1em;
  }
} 
@media screen and (max-width: 1366px) { 
  .warp-main {
    height:480px;
    overflow: overlay;
    margin-top: 0.1em;
  }
}
</style>
