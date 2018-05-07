using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UITest;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;



namespace Minerva2AutomatedRegression
{
    class HomePage
    {
        BrowserWindow localbw;
        public HomePage(BrowserWindow bw)
        {
            localbw = bw;
        }
        private HtmlSpan propertysearchlinkfield;
        private HtmlSpan loggedinusername;
        


        public HtmlSpan PropertySearchLink { get { propertysearchlinkfield = new HtmlSpan(localbw); propertysearchlinkfield.SearchProperties[HtmlSpan.PropertyNames.InnerText] = "Property Search"; return propertysearchlinkfield; } }
        public HtmlSpan Loggedinusername { get { loggedinusername = new HtmlSpan(localbw); loggedinusername.SearchProperties[HtmlSpan.PropertyNames.Class] = "d-md-down-none"; return loggedinusername;  } }

        private HtmlLabel searchbyAddress;
        public HtmlLabel SearchbyAddress
        {
            get
            {
                searchbyAddress = new HtmlLabel(localbw);
                searchbyAddress.SearchProperties[HtmlLabel.PropertyNames.InnerText] = "Search by Address";        
                return searchbyAddress;
            }
        }

        private HtmlLabel city;
        public HtmlLabel City
        {
            get
            {
                city = new HtmlLabel(localbw);
                city.SearchProperties[HtmlLabel.PropertyNames.InnerText] = "City";
                return city;
            }
        }

        private HtmlLabel state;
        public HtmlLabel State
        {
            get
            {
                state = new HtmlLabel(localbw);
                state.SearchProperties[HtmlLabel.PropertyNames.InnerText] = "State";
                return state;
            }
        }

        private HtmlLabel zip;
        public HtmlLabel Zip
        {
            get
            {
                zip = new HtmlLabel(localbw);
                zip.SearchProperties[HtmlLabel.PropertyNames.InnerText] = "Zip";
                return zip;
            }
        }

        private HtmlLabel county;
        public HtmlLabel County
        {
            get
            {
                county = new HtmlLabel(localbw);
                county.SearchProperties[HtmlLabel.PropertyNames.InnerText] = "County";
                return county;
            }
        }

        private HtmlLabel apn;
        public HtmlLabel Apn
        {
            get
            {
                apn = new HtmlLabel(localbw);
                apn.SearchProperties[HtmlLabel.PropertyNames.InnerText] = "APN";
                return apn;
            }
        }

        private HtmlLabel propertyId;
        public HtmlLabel PropertyId
        {
            get
            {
                propertyId = new HtmlLabel(localbw);
                propertyId.SearchProperties[HtmlLabel.PropertyNames.InnerText] = "Property Id";
                return propertyId;
            }
        }
        private HtmlButton searchButton;
        public HtmlButton SearchButton
        {
            get
            {
                searchButton = new HtmlButton(localbw);
                searchButton.SearchProperties[HtmlButton.PropertyNames.DisplayText] = "Search";
                return searchButton;
            }
        }

        private HtmlButton clearSearchButton;
        public HtmlButton ClearSearchButton
        {
            get
            {
                clearSearchButton = new HtmlButton(localbw);
                clearSearchButton.SearchProperties[HtmlButton.PropertyNames.DisplayText] = "Clear Search";
                return clearSearchButton;
            }
        }

        private HtmlCustom paginationText;
        public HtmlCustom PaginationText
        {
            get
            {
                paginationText = new HtmlCustom(localbw);
                paginationText.SearchProperties[HtmlCustom.PropertyNames.Class] = "k-pager-info k-label";
                paginationText.SearchProperties[HtmlCustom.PropertyNames.TagName] = "kendo-pager-info";
                return paginationText;
            }
        }

        private HtmlSpan detailedSearchlink;
        public HtmlSpan DetaieldSearchLink
        {
            get
            {
                detailedSearchlink = new HtmlSpan(localbw);
                detailedSearchlink.SearchProperties[HtmlSpan.PropertyNames.InnerText] = "Detailed Search";
                return detailedSearchlink;
            }
        }

        private HtmlLabel propertyType;
        public HtmlLabel PropertyType
        {
            get
            {
                propertyType = new HtmlLabel(localbw);
                propertyType.SearchProperties[HtmlLabel.PropertyNames.InnerText] = "Property Type";
                return propertyType;
            }
        }

        private HtmlLabel propertyPhase;
        public HtmlLabel PropertyPhase
        {
            get
            {
                propertyPhase = new HtmlLabel(localbw);
                propertyPhase.SearchProperties[HtmlLabel.PropertyNames.InnerText] = "Property Phase";
                return propertyPhase;
            }
        }

        private HtmlLabel propertyStatus;
        public HtmlLabel PropertyStatus
        {
            get
            {
                propertyStatus = new HtmlLabel(localbw);
                propertyStatus.SearchProperties[HtmlLabel.PropertyNames.InnerText] = "Property Status";
                return propertyStatus;
            }
        }

        private HtmlLabel assetType;
        public HtmlLabel AssetType
        {
            get
            {
                assetType = new HtmlLabel(localbw);
                assetType.SearchProperties[HtmlLabel.PropertyNames.InnerText] = "Asset Type";
                return assetType;
            }
        }

        private HtmlHyperlink lastPageArrow;
        public HtmlHyperlink LastPageArrow
        {
            get
            {
                lastPageArrow = new HtmlHyperlink(localbw);
                lastPageArrow.SearchProperties[HtmlHyperlink.PropertyNames.Title] = "Go to the last page";
                return lastPageArrow;
            }
        }

        private HtmlHyperlink pageSelected;
        public HtmlHyperlink PageSelected
        {
            get
            {
                pageSelected = new HtmlHyperlink(localbw);
                pageSelected.SearchProperties[HtmlHyperlink.PropertyNames.Class] = "k-link k-state-selected";
                return pageSelected;
            }
        }

        private HtmlSpan exportToExcel;
        public HtmlSpan ExportToExcel
        {
            get
            {
                exportToExcel = new HtmlSpan(localbw);
                exportToExcel.SearchProperties[HtmlSpan.PropertyNames.Class] = "k-icon k-icon-md k-i-file-excel";
                exportToExcel.SearchProperties[HtmlSpan.PropertyNames.ClassName] = "HtmlPane";
                return exportToExcel;

            }
        }
    }
}
