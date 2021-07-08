<template>
    <div class="comparative" style="padding:20px 30px 20px 23px">
        <!--工具条-->
        <div class="table_tool">
          <div class="box_search" style="padding-right:0">
            <el-row class="warp">
              <el-col :span="12">
                <el-form ref="form" :model="editForm" :inline="true" class="demo-form-inline">
                  <el-form-item><span style="font-size:14px">{{editForm.productName}}</span></el-form-item>
                  <el-form-item><span style="font-size:14px">{{editForm.equipmentName}}</span></el-form-item>
                  <el-form-item><span style="font-size:14px">{{editForm.BeginDateTime }}</span></el-form-item> /
                  <el-form-item><span style="font-size:14px">{{editForm.EndDateTime  }}</span></el-form-item>
                </el-form>
              </el-col>
              <el-col :span="12">
                <el-form ref="form" :model="compareForm" :inline="true" class="demo-form-inline">
                  <el-row><el-col span="19" style="overflow-x:auto;white-space:nowrap;">
                  <el-form-item><span style="font-size:14px">{{compareForm.productName}}</span></el-form-item>
                  <el-form-item><span style="font-size:14px">{{compareForm.equipmentName}}</span></el-form-item>
                  <el-form-item><span style="font-size:14px">{{compareForm.BeginDateTime}}</span></el-form-item> /
                  <el-form-item><span style="font-size:14px">{{compareForm.EndDateTime  }}</span></el-form-item></el-col><el-col span="5">
                  <el-button type="primary" icon="el-icon-circle-plus-outline" style="float: right"    size="mini" @click.native="showSearchDialog" >新增对比</el-button></el-col></el-row>
                </el-form>
              </el-col>
            </el-row>
          </div>
        </div>
        <el-row class="warp">
            <el-col :span="12">
              <!-- <el-form ref="form" :model="editForm" :inline="true" class="demo-form-inline">
                <el-form-item><span style="font-size:14px">{{editForm.productName}}</span></el-form-item>
                <el-form-item><span style="font-size:14px">{{editForm.equipmentName}}</span></el-form-item>
                <el-form-item><span style="font-size:14px">{{editForm.BeginDateTime }}</span></el-form-item> /
                <el-form-item><span style="font-size:14px">{{editForm.EndDateTime  }}</span></el-form-item>
              </el-form> -->
              <el-table :data="badList" highlight-current-row @selection-change="selectInfos" stripe>

                <el-table-column type="index"  width="60">
                </el-table-column>
                <el-table-column prop="defectItemName" label="缺陷"  sortable>
                </el-table-column>
                <el-table-column prop="badNum" label="不良数量"  sortable>
                </el-table-column>
                <el-table-column prop="badRate" label="不良率"  sortable>
                </el-table-column>
                <el-table-column prop="equipmentName" label="视觉检测机号"  sortable>
                </el-table-column>
              </el-table>
                <el-card style="height:300px; ">
                  <BadPChart ref="mychild1"  id="myChart1" width="100%" height="280px"  :xAxisValue="badChart.xAxisValue" :UCLValue="badChart.ucl" :LCLValue="badChart.lcl" :CLValue="badChart.badCL" :PValue="badChart.badRate" ></BadPChart>
                </el-card>
                <el-card style="height:300px;">
                  <OKPChart ref="mychild2" id="myChart2" width="100%" height="280px"  :xAxisValue="badChart.xAxisValue" :CLValue="badChart.okCL" :PValue="badChart.okRate" ></OKPChart>
                </el-card>
                <el-card style="height:400px;">
                  <ParetoChart ref="mychild3"  id="myChart3" width="100%" height="380px"  :xAxisValue="pSortChart.xAxisValue"  :PValue="pSortChart.pValue" ></ParetoChart>
                </el-card>

            </el-col>
            <el-col :span="12">
              <!-- <el-form ref="form" :model="compareForm" :inline="true" class="demo-form-inline">
                <el-form-item><span style="font-size:14px">{{compareForm.productName}}</span></el-form-item>
                <el-form-item><span style="font-size:14px">{{compareForm.equipmentName}}</span></el-form-item>
                <el-form-item><span style="font-size:14px">{{compareForm.BeginDateTime}}</span></el-form-item> /
                <el-form-item><span style="font-size:14px">{{compareForm.EndDateTime  }}</span></el-form-item>
              </el-form> -->
              <el-table :data="cbadList" highlight-current-row @selection-change="selectInfos" stripe>

                <el-table-column type="index"  width="60">
                </el-table-column>
                <el-table-column prop="defectItemName" label="缺陷"  sortable>
                </el-table-column>
                <el-table-column prop="badNum" label="不良数量"  sortable>
                </el-table-column>
                <el-table-column prop="badRate" label="不良率"  sortable>
                </el-table-column>
                <el-table-column prop="equipmentName" label="视觉检测机号"  sortable>
                </el-table-column>
              </el-table>
                <el-card style="height:300px; ">
                  <BadPChart ref="mychild4"  id="myChart4" width="100%" height="280px"  :xAxisValue="cbadChart.xAxisValue" :UCLValue="cbadChart.ucl" :LCLValue="cbadChart.lcl" :CLValue="cbadChart.badCL" :PValue="cbadChart.badRate" ></BadPChart>
                </el-card>
                <el-card style="height:300px;">
                  <OKPChart ref="mychild5" id="myChart5" width="100%" height="280px"  :xAxisValue="cbadChart.xAxisValue" :CLValue="cbadChart.okCL" :PValue="cbadChart.okRate" ></OKPChart>
                </el-card>
                <el-card style="height:400px;">
                  <ParetoChart ref="mychild6"  id="myChart6" width="100%" height="380px"  :xAxisValue="cpSortChart.xAxisValue"  :PValue="cpSortChart.pValue" ></ParetoChart>
                </el-card>

            </el-col>
        </el-row>
      <el-dialog  :visible.sync ="editFormVisible"   :before-close="closeEditDialog">
        <div slot="title">新增对比</div>
        <el-form :model="filter" label-width="120px" :rules="editFormRules" ref="editForm">
          <el-form-item label="开始时间:" prop="BeginDateTime">
            <el-date-picker v-model="compareFilter.BeginDateTime" type="datetime" placeholder="选择日期时间">
            </el-date-picker>
          </el-form-item>
          <el-form-item label="结束时间:" prop="EndDateTime">
            <el-date-picker v-model="compareFilter.EndDateTime" type="datetime" placeholder="选择日期时间">
            </el-date-picker>
          </el-form-item>
          <el-form-item label="检测机号:" prop="detection">
            <el-select v-model="compareFilter.equipmentId"  placeholder="请选择">
              <el-option
                v-for="item in equipmentOptions"
                :key="item.id"
                :label="item.name"
                :value="item.id">
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="产品名称:" prop="productName">
            <el-select v-model="compareFilter.productId"  placeholder="请选择">
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
          <el-button type="primary" @click="searchCompare" :loading="loading">查询</el-button>
        </div>
      </el-dialog>

    </div>
</template>
<script>
  import ComparativeAnalysisView from '../../../View/ComparativeAnalysisView';
  export default new ComparativeAnalysisView()
</script>

<style>
.comparative .el-col::-webkit-scrollbar {
        display: none;
    }
.comparative .box_search{
  height:26px;
  padding-right:15px
}
.comparative .warp .el-form-item{
  margin-bottom:0px;
  margin-right: 0px
}
.comparative .warp .el-form-item__content{
  height:26px;
  line-height:26px;
}
.comparative .warp .el-form{
  margin:0 15px;
  line-height:26px;
}
.comparative .warp .el-card{
    background:rgba(255,255,255,1);
    box-shadow:2px 2px 4px 0px rgba(54,125,254,0.26);
    border:1px solid rgba(234,234,234,1);
    margin: 20px 15px
}
.comparative .el-table{
    padding-right: 3px;
    margin: 10px 15px 15px 15px;
    width:auto
}
.comparative .el-table td{
    border-bottom:1px solid #E5E5E5;
    border-right: 1px solid #E5E5E5;
    padding:6px 0
}
.comparative .el-table th{
    border-right:1px solid rgba(0,80,225,1);
    border-bottom:1px solid rgba(0,80,225,1);
}
.comparative .el-table th.is-leaf{
    border-bottom:none
}
.comparative .el-table__header-wrapper{
    border-left:1px solid rgba(0,80,225,1);
    border-right:1px solid rgba(0,80,225,1);
}
.comparative .el-table__body-wrapper{
    border-left:1px solid #E5E5E5;
    border-right:1px solid #E5E5E5;
}
.comparative .el-table td .cell{
    line-height:14px;
    height:14px
}
.comparative .button{
    height: 50px;
    width: 90%;
    margin:auto;
    text-align: center;
}
.comparative .button .el-button{
    width: 100%;
    background: #E4E4E4;
    color: #747272;
    font-size: 18px;
    font-family: 方正大黑简体;
}
@media screen and (min-width: 1500px) { 
  .comparative {
    height:792px;
    overflow: overlay;
    margin-top: 0.1em;
  }
} 
@media screen and (max-width: 1366px) { 
  .comparative {
    height:480px;
    overflow: overlay;
    margin-top: 0.1em;
  }
}
</style>
