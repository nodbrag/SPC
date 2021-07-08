<template>
    <!--<div>
        <div class="box_table summary">
             <div class="header">
                <el-form :model="list" :inline="true" class="demo-form-inline">
                    <el-form-item label="Total Qty: "><span>{{list.totalQty}}</span></el-form-item>
                    <el-form-item label="OK: "><span style="color:#5BBA53">{{list.OK}}</span></el-form-item>
                    <el-form-item label="NG: "><span style="color:#FF6464">{{list.NG}}</span></el-form-item>
                    <el-form-item label="NG2: "><span>{{list.NG2}}</span></el-form-item>
                    <el-form-item label="Yield: "><span>{{list.yield}}</span></el-form-item>
                    <el-form-item label="Cycle Time: "><span>{{list.cycleTime}}</span></el-form-item>
                </el-form>
            </div>
            <div style="height:">
                <div class="table">
                    <el-table
                        :data="tableData.filter(data => !search || data.batch.toLowerCase().includes(search.toLowerCase()))"
                        :default-sort = "{prop: 'number', order: 'descending'}"
                        stripe
                        :cell-style="cellStyle"
                        style="width: 100%">
                        <el-table-column
                        label="FAI"
                        prop="FAI">
                        </el-table-column>
                        <el-table-column
                        label="OK"
                        prop="OK">
                        </el-table-column>
                        <el-table-column
                        label="NG"
                        prop="NG">
                        </el-table-column>
                        <el-table-column
                        label="Yield"
                        prop="Yield">
                        </el-table-column>
                    </el-table>
                </div>
                <div class="table">
                    <el-table
                        :data="tableData.filter(data => !search || data.batch.toLowerCase().includes(search.toLowerCase()))"
                        :default-sort = "{prop: 'number', order: 'descending'}"
                        stripe
                        :cell-style="cellStyle"
                        style="width: 100%">
                        <el-table-column
                        label="FAI"
                        prop="FAI">
                        </el-table-column>
                        <el-table-column
                        label="OK"
                        prop="OK">
                        </el-table-column>
                        <el-table-column
                        label="NG"
                        prop="NG">
                        </el-table-column>
                        <el-table-column
                        label="Yield"
                        prop="Yield">
                        </el-table-column>
                    </el-table>
                </div>
                <div class="table">
                    <el-table
                        :data="tableData.filter(data => !search || data.batch.toLowerCase().includes(search.toLowerCase()))"
                        :default-sort = "{prop: 'number', order: 'descending'}"
                        stripe
                        :cell-style="cellStyle"
                        style="width: 100%">
                        <el-table-column
                        label="FAI"
                        prop="FAI">
                        </el-table-column>
                        <el-table-column
                        label="OK"
                        prop="OK">
                        </el-table-column>
                        <el-table-column
                        label="NG"
                        prop="NG">
                        </el-table-column>
                        <el-table-column
                        label="Yield"
                        prop="Yield">
                        </el-table-column>
                    </el-table>
                </div>
                <div class="table">
                    <el-table
                        :data="tableData.filter(data => !search || data.batch.toLowerCase().includes(search.toLowerCase()))"
                        :default-sort = "{prop: 'number', order: 'descending'}"
                        stripe
                        :cell-style="cellStyle"
                        style="width: 100%">
                        <el-table-column
                        label="FAI"
                        prop="FAI">
                        </el-table-column>
                        <el-table-column
                        label="OK"
                        prop="OK">
                        </el-table-column>
                        <el-table-column
                        label="NG"
                        prop="NG">
                        </el-table-column>
                        <el-table-column
                        label="Yield"
                        prop="Yield">
                        </el-table-column>
                    </el-table>
                </div>
            </div> 
            <div style="margin-top:22px">
            <el-card style="width:104px;height:111px;padding:0px" >
                <div style="color:#666666;font-size:8px;font-family:PingFangSC-Regular;line-height:12px;height:38px;padding:3px 0 0 4px;-webkit-text-size-adjust:none">
                    Burr-D-1 100%<br>0.000/0.0400.000<br>CP/CPK(7.71/6.42)</div>
                <LittleChart  id="myChart3" :xAxisValue="xAxisValue2"  width="70px" height="70px" :PValue="PLA" ></LittleChart>
            </el-card>
            <el-card style="width:104px;height:111px;padding:0px" >
                <div style="color:#666666;font-size:8px;font-family:PingFangSC-Regular;line-height:12px;height:38px;padding:3px 0 0 4px;-webkit-text-size-adjust:none">
                    Burr-D-1 100%<br>0.000/0.0400.000<br>CP/CPK(7.71/6.42)</div>
                <LittleChart  id="myChart4" :xAxisValue="xAxisValue3"  width="70px" height="70px" :PValue="PLA3" ></LittleChart>
            </el-card>
            <el-card style="width:104px;height:111px;padding:0px" >
                <div style="color:#666666;font-size:8px;font-family:PingFangSC-Regular;line-height:12px;height:38px;padding:3px 0 0 4px;-webkit-text-size-adjust:none">
                    Burr-D-1 100%<br>0.000/0.0400.000<br>CP/CPK(7.71/6.42)</div>
                <LittleChart  id="myChart5" :xAxisValue="xAxisValue3"  width="70px" height="70px" :PValue="PLA3" ></LittleChart>
            </el-card>
            <el-card style="width:104px;height:111px;padding:0px" >
                <div style="color:#666666;font-size:8px;font-family:PingFangSC-Regular;line-height:12px;height:38px;padding:3px 0 0 4px;-webkit-text-size-adjust:none">
                    Burr-D-1 100%<br>0.000/0.0400.000<br>CP/CPK(7.71/6.42)</div>
                <LittleChart  id="myChart6" :xAxisValue="xAxisValue3"  width="70px" height="70px" :PValue="PLA3" ></LittleChart>
            </el-card>
            <el-card style="width:104px;height:111px;padding:0px" >
                <div style="color:#666666;font-size:8px;font-family:PingFangSC-Regular;line-height:12px;height:38px;padding:3px 0 0 4px;-webkit-text-size-adjust:none">
                    Burr-D-1 100%<br>0.000/0.0400.000<br>CP/CPK(7.71/6.42)</div>
                <LittleChart  id="myChart7" :xAxisValue="xAxisValue3"  width="70px" height="70px" :PValue="PLA3" ></LittleChart>
            </el-card>
            <el-card style="width:104px;height:111px;padding:0px" >
                <div style="color:#666666;font-size:8px;font-family:PingFangSC-Regular;line-height:12px;height:38px;padding:3px 0 0 4px;-webkit-text-size-adjust:none">
                    Burr-D-1 100%<br>0.000/0.0400.000<br>CP/CPK(7.71/6.42)</div>
                <LittleChart  id="myChart8" :xAxisValue="xAxisValue3"  width="70px" height="70px" :PValue="PLA3" ></LittleChart>
            </el-card>
            <el-card style="width:104px;height:111px;padding:0px" >
                <div style="color:#666666;font-size:8px;font-family:PingFangSC-Regular;line-height:12px;height:38px;padding:3px 0 0 4px;-webkit-text-size-adjust:none">
                    Burr-D-1 100%<br>0.000/0.0400.000<br>CP/CPK(7.71/6.42)</div>
                <LittleChart  id="myChart9" :xAxisValue="xAxisValue3"  width="70px" height="70px" :PValue="PLA3" ></LittleChart>
            </el-card>
            <el-card style="width:104px;height:111px;padding:0px" >
                <div style="color:#666666;font-size:8px;font-family:PingFangSC-Regular;line-height:12px;height:38px;padding:3px 0 0 4px;-webkit-text-size-adjust:none">
                    Burr-D-1 100%<br>0.000/0.0400.000<br>CP/CPK(7.71/6.42)</div>
                <LittleChart  id="myChart10" :xAxisValue="xAxisValue3"  width="70px" height="70px" :PValue="PLA3" ></LittleChart>
            </el-card>
            </div>
        </div>
    </div>-->
    <el-row>
        <el-col :span="24" class="warp-main" v-loading="loading" element-loading-text="拼命加载中">
            <div class="box_table summary">
                <div style="margin-top:22px;width:260px;float:left"  v-for="(value, key) in SummaryList">
                    <el-card style="width:245px;height:250px;padding:0px" >
                        <div style="color:#666666;font-size:12px;font-family:PingFangSC-Regular;padding:0px 0 0 10px;-webkit-text-size-adjust:none;margin:0px auto">
                            {{value.parameterName}}<br>
                            CP/CPK({{value.cpk.cp}}/{{value.cpk.cpk}})<br>
                            合格/不合格({{value.cpk.okNum}}/{{value.cpk.badNum}})
                        </div>
                        <LittleChart :id="'myChart'+key" :xAxisValue="value.xValue"  width="245px" height="280px" :PValue="value.yValue" :minValue="value.minValue" :maxValue="value.maxValue" style="position: absolute;"></LittleChart>
                    </el-card>
                    
                </div>
            </div>
        </el-col>
    </el-row>
</template>
<script>
  import DimensionSummaryView from '../../../View/DimensionSummaryView';
  export default new DimensionSummaryView()
</script>

<style lang="stylus" scope>
// @import '../../../common/common.stylus'
.summary .el-card__body{
    padding:0px
}
.summary .el-card{
    background:rgba(238,244,255,1);
    box-shadow:2px 2px 4px 0px rgba(54,125,254,0.26);
}
</style>
<style>